using System;
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
    public class RemoveAssemblyCommand : Command, ICommand
    {
        private IGlobalAssemblyCacheService gacService;
        private IGacutil gacUtilProxy;
        private IGacutilOutputParserService parserService;
        private ICommand listAssembliesCommand;
        private ILog log; 
        private DataGridView gridViewAssemblies;

        public RemoveAssemblyCommand(RemoveAssemblyCommandSettings settings, IMessageBox messageBox) : base(messageBox)
        {
            gacService = settings.GacService;
            gacUtilProxy = settings.GacUtilProxy;
            parserService = settings.ParserService;
            listAssembliesCommand = settings.ListAssembliesCommand;
            log = settings.Log;
            gridViewAssemblies = settings.GridViewAssemblies;
        }

        public void Execute()
        {
            if (this.gacUtilProxy?.Location == null)
            {
                messageBox.Show(Resources.YouNeedToConfigureLocalizationOfGacUtilToolBeforePerformingRegistration);
            }
            else
            {
                if (this.gridViewAssemblies.SelectedRows.Count == 1)
                {
                    var selectedRow = this.gridViewAssemblies.SelectedRows[0];
                    var assemblyName = Convert.ToString(selectedRow.Cells[0].Value);

                    var result = messageBox.Show(String.Format(Resources.AssemblyWillBeRemovedFromGlobalAssemblyCacheContinue, assemblyName),
                        Resources.PleaseConfirmUninstalling, MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (this.gacUtilProxy == null)
                        {
                            messageBox.Show(Resources.YouNeedToConfigureLocalizationOfGacUtilToolBeforePerformingRegistration);
                        }
                        else
                        {
                            if (this.gacService == null)
                            {
                                gacService = new GlobalAssemblyCacheService(this.gacUtilProxy, this.parserService, log);
                            }
                            var response = this.gacService.UnregisterAssembly(assemblyName);
                            if (response.Result == OperationResult.Success)
                            {
                                messageBox.Show(Resources.AssemblySuccessfullyUnregisteredFromGac);
                                Command.Invoke(listAssembliesCommand);
                            }
                            else
                            {
                                messageBox.Show($"{Resources.ErrorWhenUnregisteringAssemblyFromGac}: {response.Message}");
                            }
                        }
                    }
                }
                else
                {
                    messageBox.Show(Resources.SelectSingleAssemblyToBeUninstalledFromGac);
                }
            }
        }
    }
}
