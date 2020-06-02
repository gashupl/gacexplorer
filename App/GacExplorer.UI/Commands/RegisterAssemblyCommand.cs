using System.Windows.Forms;
using GacExplorer.CommandProxy;
using GacExplorer.Logging;
using GacExplorer.Services;
using GacExplorer.Services.OperationResults;
using GacExplorer.UI.Commands.Base;
using GacExplorer.UI.Commands.Settings;
using GacExplorer.UI.Properties;
using GacExplorer.UI.Wrappers;

namespace GacExplorer.UI.Commands
{
    public class RegisterAssemblyCommand : Command, ICommand
    {
        private IGlobalAssemblyCacheService gacService;
        private IGacutil gacUtilProxy;
        private ICommand listAssembliesCommand;
        private IGacutilOutputParserService parserService;
        private ILog log;
        private IOpenFileDialog addAssemblyFileDialog;

        public RegisterAssemblyCommand(RegisterAssemblyCommandSettings settings, IMessageBox messageBox) : base(messageBox)
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
                messageBox.Show(Resources.YouNeedToConfigureLocalizationOfGacUtilToolBeforePerformingRegistration);
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
                        messageBox.Show(Resources.AssemblySuccessfullyRegisteredInGac);
                        Command.Invoke(listAssembliesCommand);
                    }
                    else
                    {
                        messageBox.Show($"{Resources.ErrorWhenRegisteringAssemblyInGac}: {response.Message}");
                    }
                }
            }
        }
    }
}
