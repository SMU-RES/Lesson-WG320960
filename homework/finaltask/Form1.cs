using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace task
{
    public partial class Form1 : Form
    {
        private TelemetryRepository _repo;
        private TelemetryService _svc;

        // 后台采样 -> UI 刷新：用队列做线程间缓冲。
        private readonly Queue<TelemetrySample> _uiQueue = new Queue<TelemetrySample>(256);
        private readonly object _uiLock = new object();

        // 图表窗口大小：250ms 采样约 1 分钟。
        private const int MaxPoints = 240; // ~1 min (250ms)
        private bool _blinkState;
        private string _lastLevel = "OK";

        private static readonly Color OkBack = Color.FromArgb(230, 244, 234);
        private static readonly Color WarnBack = Color.FromArgb(255, 245, 204);
        private static readonly Color AlarmBack = Color.FromArgb(255, 221, 221);
        private static readonly Color AlarmStrong = Color.FromArgb(220, 68, 68);
        private static readonly Color OkStrong = Color.FromArgb(36, 128, 72);
        private static readonly Color WarnStrong = Color.FromArgb(184, 134, 11);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // UI 初始化顺序：外观 -> 配置 -> 图表 -> 载入设置 -> 默认页面。
            InitializeLook();
            InitializeConfig();
            InitializeChart();
            LoadSystemSettingsToUi();
            SwitchPage(0);

            // 数据库与采样服务。
            _repo = new TelemetryRepository(AppPaths.DatabaseFilePath);
            _repo.EnsureCreated();

            _svc = new TelemetryService(_repo, Log);
            _svc.Sample += OnSample;

            Log("SYS", "启动完成，数据库: " + AppPaths.DatabaseFilePath);
            timerUi.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 退出时停止后台任务/串口。
            try { _svc?.Dispose(); } catch { }
        }

        private void InitializeLook()
        {
            // 列表/表格开启双缓冲，降低闪烁。
            listLogs.DoubleBuffered(true);
            gridSamples.DoubleBuffered(true);
        }

        private void InitializeConfig()
        {
            cbMode.Items.Clear();
            cbMode.Items.Add("模拟仿真模式");
            cbMode.Items.Add("串口模式");
            cbMode.SelectedIndex = 0;

            cbBaud.Items.AddRange(new object[] { "9600", "19200", "38400", "57600", "115200" });
            cbBaud.SelectedIndex = 4;

            cbParity.Items.Clear();
            foreach (var p in Enum.GetValues(typeof(Parity))) cbParity.Items.Add(p);
            cbParity.SelectedItem = Parity.None;

            cbDataBits.Items.AddRange(new object[] { "7", "8" });
            cbDataBits.SelectedIndex = 1;

            cbStopBits.Items.Clear();
            cbStopBits.Items.Add(StopBits.One);
            cbStopBits.Items.Add(StopBits.OnePointFive);
            cbStopBits.Items.Add(StopBits.Two);
            cbStopBits.SelectedItem = StopBits.One;

            RefreshPorts();
        }

        private void InitializeChart()
        {
            // 三个单曲线趋势图。
            InitializeSingleTrendChart(chartTemp, "Temp (°C)", "°C", Color.FromArgb(52, 120, 208));
            InitializeSingleTrendChart(chartVolt, "Volt (V)", "V", Color.FromArgb(46, 160, 67));
            InitializeSingleTrendChart(chartRpm, "RPM", "RPM", Color.FromArgb(220, 140, 0));
        }

        private static void InitializeSingleTrendChart(Chart chart, string seriesName, string yTitle, Color color)
        {
            if (chart == null) return;

            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Legends.Clear();

            var area = new ChartArea("Main")
            {
                BackColor = Color.White
            };

            area.AxisX.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);

            area.AxisX.LabelStyle.ForeColor = Color.FromArgb(80, 80, 80);
            area.AxisY.LabelStyle.ForeColor = Color.FromArgb(80, 80, 80);

            area.AxisX.LineColor = Color.FromArgb(180, 180, 180);
            area.AxisY.LineColor = Color.FromArgb(180, 180, 180);

            area.AxisX.MajorTickMark.LineColor = Color.FromArgb(180, 180, 180);
            area.AxisY.MajorTickMark.LineColor = Color.FromArgb(180, 180, 180);

            area.AxisX.Title = "Time";
            area.AxisY.Title = yTitle;
            area.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;

            chart.ChartAreas.Add(area);

            chart.Legends.Add(new Legend("Legend")
            {
                Docking = Docking.Top,
                Alignment = StringAlignment.Center,
                BackColor = Color.Transparent
            });

            chart.Series.Add(new Series(seriesName)
            {
                ChartType = SeriesChartType.FastLine,
                ChartArea = "Main",
                Color = color,
                BorderWidth = 2,
                XValueType = ChartValueType.DateTime,
                Legend = "Legend"
            });
        }

        private void InitializeLookUnsafeStatus(string level)
        {
            // 报警区域只反映当前级别（OK/WARN/ALARM）。
            _lastLevel = level;

            if (level == "OK")
            {
                timerBlink.Stop();
                panelAlarm.BackColor = OkBack;
                lblAlarmText.ForeColor = OkStrong;
                lblAlarmText.Text = "状态：安全 (OK)";
                return;
            }

            if (level == "WARN")
            {
                timerBlink.Stop();
                panelAlarm.BackColor = WarnBack;
                lblAlarmText.ForeColor = WarnStrong;
                lblAlarmText.Text = "状态：预警 (WARN)";
                return;
            }

            _blinkState = false;
            timerBlink.Start();
            lblAlarmText.Text = "状态：报警 (ALARM)";
        }

        private void OnSample(TelemetrySample s)
        {
            // 后台线程回调：仅入队，UI 线程定时批量消费。
            lock (_uiLock)
            {
                if (_uiQueue.Count > 400) _uiQueue.Dequeue();
                _uiQueue.Enqueue(s);
            }
        }

        private void timerUi_Tick(object sender, EventArgs e)
        {
            // 批量取出，降低锁竞争。
            lock (_uiLock)
            {
                if (_uiQueue.Count == 0) return;
            }

            List<TelemetrySample> batch;
            lock (_uiLock)
            {
                batch = _uiQueue.ToList();
                _uiQueue.Clear();
            }

            TelemetrySample latest = null;
            foreach (var s in batch)
            {
                latest = s;
                AppendChartPoint(s);

                if (s.Level != _lastLevel) InitializeLookUnsafeStatus(s.Level);

                if (s.Level == "ALARM")
                {
                    // 报警提示：仅保留状态闪烁/日志（避免重复弹窗）。
                }
            }

            if (latest == null) return;

            lblTempValue.Text = latest.TemperatureC.ToString("0.0");
            lblVoltValue.Text = latest.VoltageV.ToString("0.00");
            lblRpmValue.Text = latest.Rpm.ToString("0");
        }

        private void timerBlink_Tick(object sender, EventArgs e)
        {
            // ALARM 状态下闪烁。
            if (_lastLevel != "ALARM")
            {
                timerBlink.Stop();
                return;
            }

            _blinkState = !_blinkState;
            panelAlarm.BackColor = _blinkState ? AlarmBack : Color.White;
            lblAlarmText.ForeColor = _blinkState ? AlarmStrong : Color.FromArgb(120, 0, 0);
        }

        private void AppendChartPoint(TelemetrySample s)
        {
            var ts = s.TimestampUtc.ToLocalTime();

            AppendChartPoint(chartTemp, ts, s.TemperatureC);
            AppendChartPoint(chartVolt, ts, s.VoltageV);
            AppendChartPoint(chartRpm, ts, s.Rpm);
        }

        private void AppendChartPoint(Chart chart, DateTime ts, double y)
        {
            if (chart == null || chart.Series.Count == 0 || chart.ChartAreas.Count == 0) return;

            var series = chart.Series[0];
            series.Points.AddXY(ts, y);

            while (series.Points.Count > MaxPoints) series.Points.RemoveAt(0);

            if (series.Points.Count < 2) return;

            var xmin = series.Points[0].XValue;
            var xmax = series.Points[series.Points.Count - 1].XValue;

            var area = chart.ChartAreas[0];
            area.AxisX.Minimum = xmin;
            area.AxisX.Maximum = xmax;
        }

        private void btnRefreshPorts_Click(object sender, EventArgs e) => RefreshPorts();

        private void RefreshPorts()
        {
            // 每次刷新重新枚举可用串口。
            var ports = SerialPort.GetPortNames().OrderBy(p => p).ToArray();
            cbPort.Items.Clear();
            cbPort.Items.AddRange(ports);
            if (ports.Length > 0) cbPort.SelectedIndex = 0;
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (_svc == null) return;

            if (_svc.IsRunning)
            {
                _svc.Stop();
                btnStartStop.Text = "Start";
                btnStartStop.BackColor = Color.White;
                Log("SYS", "采集停止");
                return;
            }

            var mode = cbMode.SelectedIndex == 0 ? "SIM" : "SER";

            try
            {
                _svc.SetThresholds((double)numWarnTemp.Value, (double)numAlarmTemp.Value);

                if (mode == "SIM")
                {
                    _svc.StartSim(250);
                    btnStartStop.Text = "Stop";
                    return;
                }

                if (cbPort.SelectedItem == null)
                {
                    MessageBox.Show(this, "未发现串口端口。请点击“刷新端口”或插入设备后重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var port = cbPort.SelectedItem.ToString();
                var baud = int.Parse(cbBaud.SelectedItem.ToString());
                var parity = (Parity)cbParity.SelectedItem;
                var dataBits = int.Parse(cbDataBits.SelectedItem.ToString());
                var stopBits = (StopBits)cbStopBits.SelectedItem;

                _svc.StartSerial(port, baud, parity, dataBits, stopBits);
                btnStartStop.Text = "Stop";
            }
            catch (Exception ex)
            {
                Log("ERR", "启动失败: " + ex.Message);
                MessageBox.Show(this, ex.Message, "启动失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbnTabs_SelectedIndexChanged(object sender, EventArgs e) => SwitchPage(rbnTabs.SelectedIndex);

        private void SwitchPage(int index)
        {
            // 简单的“页面切换”：用 Visible + BringToFront。
            pageDashboard.Visible = index == 0;
            pageSettings.Visible = index == 1;
            pageDatabase.Visible = index == 2;

            pageDashboard.BringToFront();
            if (index == 1) pageSettings.BringToFront();
            else if (index == 2) pageDatabase.BringToFront();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            SaveSystemSettingsFromUi();
            Log("SYS", "系统配置已保存");
        }

        private void LoadSystemSettingsToUi()
        {
            numWarnTemp.Value = (decimal)AppSettings.Current.WarnTempC;
            numAlarmTemp.Value = (decimal)AppSettings.Current.AlarmTempC;
            numMaxRows.Value = AppSettings.Current.MaxTelemetryRows;
        }

        private void SaveSystemSettingsFromUi()
        {
            AppSettings.Current.WarnTempC = (double)numWarnTemp.Value;
            AppSettings.Current.AlarmTempC = (double)numAlarmTemp.Value;
            AppSettings.Current.MaxTelemetryRows = (int)numMaxRows.Value;
            AppSettings.Save();

            // 保存配置后按上限裁剪数据库。
            try { _repo?.TrimTelemetrySamples(AppSettings.Current.MaxTelemetryRows); } catch { }
        }

        private void btnDbLoadSamples_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = _repo.QueryTelemetrySamples(5000);
                gridSamples.DataSource = dt;
                Log("DB", "已加载采样数据: " + dt.Rows.Count);
            }
            catch (Exception ex)
            {
                Log("ERR", "查询失败: " + ex.Message);
            }
        }

        private void btnDbDeleteSample_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridSamples.CurrentRow == null) return;

                var idObj = gridSamples.CurrentRow.Cells["Id"].Value;
                if (idObj == null) return;

                var id = Convert.ToInt64(idObj);
                _repo.DeleteTelemetrySample(id);
                btnDbLoadSamples_Click(sender, e);
                Log("DB", "已删除 Id=" + id);
            }
            catch (Exception ex)
            {
                Log("ERR", "删除失败: " + ex.Message);
            }
        }

        private void btnDbExportCsv_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = gridSamples.DataSource as DataTable;
                if (dt == null || dt.Rows.Count == 0) return;

                using (var sfd = new SaveFileDialog
                {
                    Filter = "CSV Files (*.csv)|*.csv",
                    FileName = "TelemetrySamples.csv"
                })
                {
                    if (sfd.ShowDialog(this) != DialogResult.OK) return;

                    WriteCsv(dt, sfd.FileName);
                    Log("DB", "已导出: " + sfd.FileName);
                }
            }
            catch (Exception ex)
            {
                Log("ERR", "导出失败: " + ex.Message);
            }
        }

        private static void WriteCsv(DataTable dt, string filePath)
        {
            var sb = new StringBuilder();

            // 表头。
            for (var i = 0; i < dt.Columns.Count; i++)
            {
                if (i > 0) sb.Append(',');
                sb.Append(EscapeCsv(dt.Columns[i].ColumnName));
            }
            sb.AppendLine();

            // 行数据。
            foreach (DataRow row in dt.Rows)
            {
                for (var i = 0; i < dt.Columns.Count; i++)
                {
                    if (i > 0) sb.Append(',');
                    sb.Append(EscapeCsv(Convert.ToString(row[i])));
                }
                sb.AppendLine();
            }

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        private static string EscapeCsv(string s)
        {
            if (s == null) return string.Empty;

            // RFC4180 基础转义：包含分隔符/引号/换行时整体加引号。
            var mustQuote = s.IndexOfAny(new[] { ',', '"', '\r', '\n' }) >= 0;
            if (!mustQuote) return s;

            return "\"" + s.Replace("\"", "\"\"") + "\"";
        }

        private void Log(string category, string message)
        {
            // 先尝试落库，再写 UI。
            try { _repo?.InsertLog(category, message); } catch { }

            if (IsDisposed) return;
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => Log(category, message)));
                return;
            }

            var time = DateTime.Now.ToString("HH:mm:ss.fff");
            var item = new ListViewItem(new[] { time, category, message });

            if (category == "ERR") item.ForeColor = AlarmStrong;
            else if (category == "DB") item.ForeColor = Color.FromArgb(90, 90, 90);
            else if (category == "CMD") item.ForeColor = Color.FromArgb(30, 45, 66);

            listLogs.Items.Add(item);
            while (listLogs.Items.Count > 500) listLogs.Items.RemoveAt(0);
            listLogs.EnsureVisible(listLogs.Items.Count - 1);
        }

        private void btnMotorStart_Click(object sender, EventArgs e) => Log("CMD", "电机启动");
        private void btnMotorStop_Click(object sender, EventArgs e) => Log("CMD", "电机停止");
        private void btnLedToggle_Click(object sender, EventArgs e) => Log("CMD", "LED 开关");
    }

    internal static class ControlExtensions
    {
        public static void DoubleBuffered(this Control control, bool enable)
        {
            var prop = typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            prop?.SetValue(control, enable, null);
        }
    }
}
