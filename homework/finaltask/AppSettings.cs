using System;
using System.Globalization;
using System.IO;

namespace task
{
    internal sealed class AppSettings
    {
        // 温度阈值（单位：°C）。
        public double WarnTempC { get; set; } = 65;
        public double AlarmTempC { get; set; } = 75;

        // 数据库最多保留的采样行数（超出会裁剪）。
        public int MaxTelemetryRows { get; set; } = 5000;

        public static AppSettings Current { get; private set; } = new AppSettings();

        // settings.ini 与数据库放在同一目录，便于打包/迁移。
        private static string SettingsFilePath => Path.Combine(
            Path.GetDirectoryName(AppPaths.DatabaseFilePath) ?? AppDomain.CurrentDomain.BaseDirectory,
            "settings.ini");

        public static void Load()
        {
            var s = new AppSettings();

            try
            {
                if (File.Exists(SettingsFilePath))
                {
                    foreach (var raw in File.ReadAllLines(SettingsFilePath))
                    {
                        var line = (raw ?? string.Empty).Trim();
                        if (line.Length == 0 || line.StartsWith("#")) continue;

                        // INI: key=value
                        var idx = line.IndexOf('=');
                        if (idx <= 0) continue;

                        var key = line.Substring(0, idx).Trim();
                        var val = line.Substring(idx + 1).Trim();

                        if (key.Equals("WarnTempC", StringComparison.OrdinalIgnoreCase))
                            s.WarnTempC = ParseDouble(val, s.WarnTempC);
                        else if (key.Equals("AlarmTempC", StringComparison.OrdinalIgnoreCase))
                            s.AlarmTempC = ParseDouble(val, s.AlarmTempC);
                        else if (key.Equals("MaxTelemetryRows", StringComparison.OrdinalIgnoreCase))
                            s.MaxTelemetryRows = ParseInt(val, s.MaxTelemetryRows);
                    }
                }
            }
            catch
            {
            }

            // 规整输入，保证阈值与保留行数可用。
            if (s.AlarmTempC < s.WarnTempC) s.AlarmTempC = s.WarnTempC + 1;
            if (s.MaxTelemetryRows < 100) s.MaxTelemetryRows = 100;

            Current = s;
        }

        public static void Save()
        {
            try
            {
                var dir = Path.GetDirectoryName(SettingsFilePath);
                if (!string.IsNullOrWhiteSpace(dir)) Directory.CreateDirectory(dir);

                var nl = Environment.NewLine;
                var text =
                    "WarnTempC=" + Current.WarnTempC.ToString(CultureInfo.InvariantCulture) + nl +
                    "AlarmTempC=" + Current.AlarmTempC.ToString(CultureInfo.InvariantCulture) + nl +
                    "MaxTelemetryRows=" + Current.MaxTelemetryRows.ToString(CultureInfo.InvariantCulture) + nl;

                File.WriteAllText(SettingsFilePath, text);
            }
            catch
            {
            }
        }

        private static double ParseDouble(string s, double fallback)
        {
            // 优先用不变文化解析，兼容不同系统小数点。
            if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out var v)) return v;
            if (double.TryParse(s, NumberStyles.Float, CultureInfo.CurrentCulture, out v)) return v;
            return fallback;
        }

        private static int ParseInt(string s, int fallback)
        {
            if (int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var v)) return v;
            if (int.TryParse(s, NumberStyles.Integer, CultureInfo.CurrentCulture, out v)) return v;
            return fallback;
        }
    }
}
