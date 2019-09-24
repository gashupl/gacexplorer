using GacExplorer.CommandProxy;
using GacExplorer.Services;
using GacExplorer.Services.Wrappers;
using SimpleInjector;
using System;
using System.Windows.Forms;

namespace GacExplorer.UI
{
    static class Program
    {
        public static Container container;


        [STAThread]
        static void Main()
        {
            Bootstrap(); 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.GetInstance<MainForm>());
        }

        private static void Bootstrap()
        {
            container = new Container();
            container.Register<IFile, FileWrapper>();
            container.Register<IGacutil, Gacutil>(); 

            container.Register<IApplicationConfigurationService, ApplicationConfigurationService>();
            container.Register<IGacutilLocationService, GacutilLocationService>();
            container.Register<IGlobalAssemblyCacheService, GlobalAssemblyCacheService>(); 

            container.Verify();
        }

    }
}
