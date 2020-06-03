using System.Windows.Forms;

namespace GacExplorer.UI.Wrappers
{
    class MessageBoxWrapper : IMessageBox 
    {
        public DialogResult Show(string text)
        {
            return MessageBox.Show(text); 
        }

        public DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            return MessageBox.Show(text, caption, buttons); 
        }
    }
}
