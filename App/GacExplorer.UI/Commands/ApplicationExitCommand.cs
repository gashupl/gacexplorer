using System.Windows.Forms;
using GacExplorer.UI.Commands.Base;
using GacExplorer.UI.Wrappers;

namespace GacExplorer.UI.Commands
{
    public class ApplicationExitCommand : ICommand
    {
        private IApplication application;

        public ApplicationExitCommand(IApplication application)
        {
            this.application = application; 
        }
        public void Execute()
        {
            this.application.Exit();
        }
    }
}
