using System.Windows.Forms;
using GacExplorer.UI.Commands.Base;

namespace GacExplorer.UI.Commands
{
    public class ApplicationExitCommand : ICommand
    {
        public void Execute()
        {
            Application.Exit();
        }
    }
}
