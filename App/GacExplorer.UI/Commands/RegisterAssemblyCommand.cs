using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GacExplorer.CommandProxy;
using GacExplorer.Logging;
using GacExplorer.Services;
using GacExplorer.Services.OperationResults;
using GacExplorer.UI.Commands.Base;
using GacExplorer.UI.Commands.Settings;
using GacExplorer.UI.Properties;

namespace GacExplorer.UI.Commands
{
    public class RegisterAssemblyCommand : ICommand
    {
        private IGlobalAssemblyCacheService gacService;
        private IGacutil gacUtilProxy;
        private ICommand listAssembliesCommand;
        private IGacutilOutputParserService parserService;
        private ILog log;
        private OpenFileDialog addAssemblyFileDialog;

        public RegisterAssemblyCommand(RegisterAssemblyCommandSettings settings)
        {
            gacService = settings.GacService;
            gacUtilProxy = settings.GacUtilProxy;
            listAssembliesCommand = settings.ListAssembliesCommand;
            addAssemblyFileDialog = settings.AddAssemblyFileDialog;
            parserService = settings.ParserService;
            log = settings.Log; 
        }

        public void Execute()
        {
            if (this.gacUtilProxy?.Location == null)
            {
                MessageBox.Show(Resources.YouNeedToConfigureLocalizationOfGacUtilToolBeforePerformingRegistration);
            }
            else
            {
                var result = this.addAssemblyFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (this.gacService == null)
                    {
                        gacService = new GlobalAssemblyCacheService(this.gacUtilProxy, this.parserService, log);
                    }
                    var response = this.gacService.RegisterAssembly(this.addAssemblyFileDialog.FileName);
                    if (response.Result == OperationResult.Success)
                    {
                        MessageBox.Show(Resources.AssemblySuccessfullyRegisteredInGac);
                        Command.Invoke(listAssembliesCommand);
                    }
                    else
                    {
                        MessageBox.Show($"{Resources.ErrorWhenRegisteringAssemblyInGac}: {response.Message}");
                    }
                }
            }
        }
    }
}
