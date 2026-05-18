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
            ApplicationConfiguration.Initialize();

            f_Login loginForm = new f_Login();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new f_ListStudent());
            }
        }
    }
}