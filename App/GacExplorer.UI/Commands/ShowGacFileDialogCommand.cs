using System.Windows.Forms;
using GacExplorer.CommandProxy;
using GacExplorer.Services;
using GacExplorer.UI.Commands.Base;

namespace GacExplorer.UI.Commands
{
    public class ShowGacFileDialogCommand : ICommand
    {
        private OpenFileDialog openGacFileDialog;
        private IGacutilLocationService gacutilLocationService;
        private IGacutil gacUtilProxy;

        public DialogResult ShowGacFileDialogResult { get; private set; }
        public ShowGacFileDialogCommand(OpenFileDialog openGacFileDialog, IGacutilLocationService gacutilLocationService, IGacutil gacUtilProxy)
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
                this.gacutilLocationService.Save(fileLocation);
                this.gacUtilProxy.Location = fileLocation; 

            }
            this.openGacFileDialog.Dispose();
            ShowGacFileDialogResult =  result;
        }
    }
}
