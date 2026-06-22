namespace ProjectMonHoc
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // ── Khởi động DB Leak Monitor ────────────────────────────
            DbLeakMonitor.Instance.ScanIntervalMs         = 30_000; // quét mỗi 30 giây
            DbConnectionLogger.LeakThresholdSeconds       = 60;     // cảnh báo sau 60 giây
            DbLeakMonitor.Instance.Start();

            // ── Dọn dẹp khi app kết thúc ────────────────────────────
            Application.ApplicationExit += (_, _) =>
            {
                DbLeakMonitor.Instance.Stop();
                DbConnectionLogger.Flush(); // ghi summary vào log
            };

            ApplicationConfiguration.Initialize();

            // Khởi tạo các bảng Database (VD: LoginLogs)
            ProjectMonHoc.Classes.DatabaseInitializer.Initialize();

            f_Login loginForm = new f_Login();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new f_Login());
            }
        }
    }
}