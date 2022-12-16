/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(c) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/
namespace MCM8
{
    internal static class Program
    {
        private static Form1? frm = null;
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            
            Application.EnableVisualStyles();
            ApplicationConfiguration.Initialize();
            frm = new Form1();
            Application.Run(frm);
        }
        static void Application_ThreadException (object sender, ThreadExceptionEventArgs ex) =>
            ShowExceptionDetails(ex.Exception);

        static void CurrentDomain_UnhandledException (object sender, UnhandledExceptionEventArgs ex)
        {
            if (ex == null) return;
            Exception? exp = ex.ExceptionObject as Exception;
            if (exp == null) return;
            ShowExceptionDetails(exp);
        }

        static void ShowExceptionDetails(Exception ex)
        {
            if (frm != null)
                frm.ToLog($"({ex.TargetSite}) {ex.Message}");
            else
#               pragma warning disable CS8602
                MessageBox.Show(ex.Message, ex.TargetSite.ToString(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
#               pragma warning restore CS8602
        }
    }
}