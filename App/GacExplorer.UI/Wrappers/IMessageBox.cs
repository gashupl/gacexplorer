using System.Windows.Forms;

namespace GacExplorer.UI.Wrappers
{
    public interface IMessageBox
    {
        DialogResult Show(string text);

        DialogResult Show(string text, string caption, MessageBoxButtons buttons); 
    }
}
