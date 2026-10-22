using System;
using System.IO;

namespace task
{
    internal static class AppPaths
    {
        // 本机用户目录下的数据文件夹：%LocalAppData%/IndustrialTelemetryDashboard
        public static string AppDataDir
        {
            get
            {
                var baseDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var dir = Path.Combine(baseDir, "IndustrialTelemetryDashboard");
                Directory.CreateDirectory(dir);
                return dir;
            }
        }

        // 采样数据库文件路径。
        public static string DatabaseFilePath => Path.Combine(AppDataDir, "telemetry.sqlite");
    }
}
