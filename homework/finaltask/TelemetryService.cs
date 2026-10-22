using System;
using System.Collections.Concurrent;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace task
{
    // 采集服务：SIM 模拟生成 or 串口读取，异步写库并向 UI 推送。
    internal sealed class TelemetryService : IDisposable
    {
        private readonly TelemetryRepository _repo;
        private readonly Action<string, string> _log;
        private readonly ConcurrentQueue<TelemetrySample> _queue = new ConcurrentQueue<TelemetrySample>();

        private CancellationTokenSource _cts;
        private Task _writerTask;

        private SerialPort _port;
        private readonly Random _rnd = new Random();

        private double _warnTempC = 65;
        private double _alarmTempC = 75;

        public event Action<TelemetrySample> Sample;

        public bool IsRunning { get; private set; }
        public string Mode { get; private set; } = "SIM";

        public TelemetryService(TelemetryRepository repo, Action<string, string> log)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _log = log ?? ((_, __) => { });
        }

        public void SetThresholds(double warnTempC, double alarmTempC)
        {
            // 保护性设置：保证阈值有意义且 ALARM > WARN。
            if (warnTempC <= 0) warnTempC = 65;
            if (alarmTempC <= 0) alarmTempC = 75;
            if (alarmTempC < warnTempC) alarmTempC = warnTempC + 1;

            _warnTempC = warnTempC;
            _alarmTempC = alarmTempC;
        }

        public void StartSim(int intervalMs = 250)
        {
            Stop();

            Mode = "SIM";
            _cts = new CancellationTokenSource();
            StartWriter(_cts.Token);

            IsRunning = true;
            _log("SYS", "切换为模拟仿真模式");

            // 模拟采样：按固定周期生成波形数据。
            Task.Run(async () =>
            {
                var t0 = Environment.TickCount;

                while (!_cts.IsCancellationRequested)
                {
                    var seconds = (Environment.TickCount - t0) / 1000.0;
                    var temp = 42 + 10 * Math.Sin(seconds / 2.5) + _rnd.NextDouble() * 2.0;
                    var volt = 12.0 + 0.6 * Math.Sin(seconds / 4.0) + (_rnd.NextDouble() - 0.5) * 0.2;
                    var rpm = 1500 + 500 * Math.Sin(seconds / 3.5) + (_rnd.NextDouble() - 0.5) * 120;

                    var level = temp >= _alarmTempC ? "ALARM" : (temp >= _warnTempC ? "WARN" : "OK");
                    Enqueue(new TelemetrySample
                    {
                        TimestampUtc = DateTime.UtcNow,
                        TemperatureC = temp,
                        VoltageV = volt,
                        Rpm = rpm,
                        Source = "SIM",
                        Level = level
                    });

                    await Task.Delay(intervalMs).ConfigureAwait(false);
                }
            }, _cts.Token);
        }

        public void StartSerial(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            Stop();

            Mode = portName;
            _cts = new CancellationTokenSource();
            StartWriter(_cts.Token);

            _port = new SerialPort(portName, baudRate, parity, dataBits, stopBits)
            {
                NewLine = "\n",
                ReadTimeout = 1000,
                WriteTimeout = 1000
            };

            _port.DataReceived += (_, __) =>
            {
                try
                {
                    // 一行一条采样。
                    var line = _port.ReadLine();

                    // 格式: TEMP=23.4;V=12.1;RPM=1200
                    var parsed = ParseLine(line);
                    if (parsed != null) Enqueue(parsed);
                }
                catch
                {
                }
            };

            _port.Open();

            IsRunning = true;
            _log("SYS", $"串口已打开: {portName} @ {baudRate}");
        }

        private TelemetrySample ParseLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return null;

            try
            {
                double temp = double.NaN, v = double.NaN, rpm = double.NaN;

                var parts = line.Trim().Split(';');
                foreach (var p in parts)
                {
                    var kv = p.Split('=');
                    if (kv.Length != 2) continue;

                    var key = kv[0].Trim().ToUpperInvariant();
                    var val = kv[1].Trim();

                    if (key == "TEMP") temp = double.Parse(val);
                    else if (key == "V") v = double.Parse(val);
                    else if (key == "RPM") rpm = double.Parse(val);
                }

                if (double.IsNaN(temp) || double.IsNaN(v) || double.IsNaN(rpm)) return null;

                var level = temp >= _alarmTempC ? "ALARM" : (temp >= _warnTempC ? "WARN" : "OK");

                return new TelemetrySample
                {
                    TimestampUtc = DateTime.UtcNow,
                    TemperatureC = temp,
                    VoltageV = v,
                    Rpm = rpm,
                    Source = _port?.PortName ?? "SER",
                    Level = level
                };
            }
            catch
            {
                return null;
            }
        }

        private void StartWriter(CancellationToken ct)
        {
            // 单写线程：从队列取样本 -> 写库 -> 通知 UI。
            _writerTask = Task.Run(async () =>
            {
                while (!ct.IsCancellationRequested)
                {
                    while (_queue.TryDequeue(out var s))
                    {
                        try
                        {
                            _repo.InsertSample(s);
                        }
                        catch (Exception ex)
                        {
                            _log("DB", "写入样本失败: " + ex.Message);
                        }

                        try
                        {
                            Sample?.Invoke(s);
                        }
                        catch
                        {
                        }
                    }

                    await Task.Delay(50).ConfigureAwait(false);
                }
            }, ct);
        }

        private void Enqueue(TelemetrySample s) => _queue.Enqueue(s);

        public void Stop()
        {
            if (!IsRunning && _cts == null) return;

            try { _cts?.Cancel(); } catch { }

            try
            {
                if (_port == null) return;

                if (_port.IsOpen) _port.Close();
                _port.Dispose();
            }
            catch
            {
            }
            finally
            {
                _port = null;
            }

            IsRunning = false;
        }

        public void Dispose()
        {
            Stop();
            try { _cts?.Dispose(); } catch { }
        }
    }
}
