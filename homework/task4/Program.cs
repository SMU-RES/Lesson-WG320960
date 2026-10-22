using System;
using System.Windows.Forms;
using task4.Data;
using task4.Forms;
using task4.Infrastructure;

namespace task4
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += (s, e) =>
            {
                Logger.Error("UI thread exception", e.Exception);
                MessageBox.Show("程序发生异常：" + e.Exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                var ex = e.ExceptionObject as Exception;
                Logger.Error("Unhandled exception", ex ?? new Exception(Convert.ToString(e.ExceptionObject)));
            };

            try
            {
                SQLiteDb.Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库初始化失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var login = new LoginForm())
            {
                if (login.ShowDialog() != DialogResult.OK)
                    return;
            }

            Application.Run(new MainForm());
        }
    }
}
