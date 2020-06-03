using System.Windows.Forms;

namespace GacExplorer.UI.Wrappers
{
    internal class ApplicationWrapper : IApplication
    {
        public void Exit()
        {
            Application.Exit(); 
        }
    }
}