using System.Windows.Forms;
using GacExplorer.CommandProxy;
using GacExplorer.Services;
using GacExplorer.Services.OperationResults;
using GacExplorer.UI.Commands.Base;
using GacExplorer.UI.Properties;
using GacExplorer.UI.Wrappers;

namespace GacExplorer.UI.Commands
{
    public class ShowGacFileDialogCommand : Command, ICommand
    {
        private IOpenFileDialog openGacFileDialog;
        private IGacutilLocationService gacutilLocationService;
        private IGacutil gacUtilProxy;

        public DialogResult ShowGacFileDialogResult { get; private set; }
        public ShowGacFileDialogCommand(IOpenFileDialog openGacFileDialog, IGacutilLocationService gacutilLocationService, IGacutil gacUtilProxy, IMessageBox messageBox) : base(messageBox)
        {
            this.openGacFileDialog = openGacFileDialog;
            this.gacutilLocationService = gacutilLocationService;
            this.gacUtilProxy = gacUtilProxy; 
        }

        public void Execute()
        {
            var result = this.openGacFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fileLocation = this.openGacFileDialog.FileName;
                var saveResult = this.gacutilLocationService.Save(fileLocation);
                if (saveResult.Result == OperationResult.Success)
                {
                    this.gacUtilProxy.Location = fileLocation;
                }
                else
                {
                    messageBox.Show($"{Resources.ErrorWhenSavingGacUtilLocation}: {saveResult.Message}");
                }

            }
            this.openGacFileDialog.Dispose();
            ShowGacFileDialogResult =  result;
        }
    }
}
