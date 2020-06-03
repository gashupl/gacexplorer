using System.Windows.Forms;

namespace GacExplorer.UI.Wrappers
{
    public interface IOpenFileDialog
    {
        string FileName { get; set; }

        DialogResult ShowDialog();

        void Dispose(); 
    }

}
