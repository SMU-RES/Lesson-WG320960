using System;
using System.Windows.Forms;

namespace task
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序入口。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 读取本地 settings.ini（阈值/保留行数等）。
            AppSettings.Load();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
