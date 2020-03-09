using System.Windows.Forms;

namespace GacExplorer.UI.Wrappers
{
    class OpenFileDialogWrapper : IOpenFileDialog
    {
        private OpenFileDialog openFileDialog; 
        public OpenFileDialogWrapper(OpenFileDialog openFileDialog)
        {
            this.openFileDialog = openFileDialog; 
        }

        public string FileName { get; set; }

        public DialogResult ShowDialog()
        {
            return openFileDialog.ShowDialog(); 
        }

        public void Dispose()
        {
            openFileDialog.Dispose(); 
        }
    }
}
