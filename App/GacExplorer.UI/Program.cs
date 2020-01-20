using GacExplorer.Services;
using GacExplorer.Services.Wrappers;
using SimpleInjector;
using System;
using System.Threading;
using System.Windows.Forms;
using GacExplorer.CommandProxy;
using GacExplorer.Logging;

namespace GacExplorer.UI
{
    static class Program
    {
        public static Container Container;
        public static Log Log; 

        [STAThread]
        static void Main()
        {
            Log = new Log(); 
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Bootstrap(); 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.GetInstance<MainForm>());
        }

        private static void Bootstrap()
        {
            Container = new Container();
            Container.Register<IFile, FileWrapper>();
            Container.Register<ILog, Log>();
            Container.Register<IGacutil, Gacutil>();
            Container.Register<IApplicationConfigurationService, ApplicationConfigurationService>();
            Container.Register<IGacutilLocationService, GacutilLocationService>();
            Container.Register<IGacutilOutputParserService, GacutilOutputParserService>();
            Container.Verify();
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Log.Error(e.Exception, nameof(Application_ThreadException));
            ShowExceptionDetails(e.Exception);
        }

        static void CurrentDomain_UnhandledException (object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            if (exception != null)
            {
                Log.Error(exception, nameof(Program.CurrentDomain_UnhandledException));
                ShowExceptionDetails(e.ExceptionObject as Exception);
                Thread.CurrentThread.Suspend();
            }
        }

        static void ShowExceptionDetails(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.TargetSite.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
