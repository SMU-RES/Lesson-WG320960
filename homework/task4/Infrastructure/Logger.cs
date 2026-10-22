using System;
using System.Globalization;
using System.IO;
using System.Text;
using task4.Data;

namespace task4.Infrastructure
{
    internal static class Logger
    {
        private static readonly object Sync = new object();

        public static void Info(string message) => Write("INFO", message, null);
        public static void Warn(string message) => Write("WARN", message, null);
        public static void Error(string message, Exception ex) => Write("ERROR", message, ex);

        private static void Write(string level, string message, Exception ex)
        {
            try
            {
                var file = Path.Combine(DbPaths.LogsDir, "app-" + DateTime.Now.ToString("yyyyMMdd", CultureInfo.InvariantCulture) + ".log");
                var line = BuildLine(level, message, ex);

                lock (Sync)
                {
                    File.AppendAllText(file, line + Environment.NewLine, Encoding.UTF8);
                }
            }
            catch
            {
                // ignore logging failures
            }
        }

        private static string BuildLine(string level, string message, Exception ex)
        {
            var ts = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
            if (ex == null)
                return string.Format(CultureInfo.InvariantCulture, "[{0}] [{1}] {2}", ts, level, message);

            return string.Format(CultureInfo.InvariantCulture, "[{0}] [{1}] {2} | {3}", ts, level, message, ex);
        }
    }
}
