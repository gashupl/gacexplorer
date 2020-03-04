using System.Windows.Forms;

namespace GacExplorer.UI.Wrappers
{
    internal class ApplicationWrapper : IApplicationWrapper
    {
        public void Exit()
        {
            Application.Exit(); 
        }
    }
}