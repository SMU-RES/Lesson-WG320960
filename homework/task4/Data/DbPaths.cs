using System;
using System.IO;

namespace task4.Data
{
    internal static class DbPaths
    {
        public static string AppDataDir
        {
            get
            {
                var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "task4-library");
                Directory.CreateDirectory(dir);
                return dir;
            }
        }

        public static string DbFilePath => Path.Combine(AppDataDir, "library.db");
        public static string LogsDir
        {
            get
            {
                var dir = Path.Combine(AppDataDir, "logs");
                Directory.CreateDirectory(dir);
                return dir;
            }
        }
    }
}
