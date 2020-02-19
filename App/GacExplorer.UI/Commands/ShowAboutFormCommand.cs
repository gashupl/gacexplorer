using GacExplorer.UI.Commands.Base;

namespace GacExplorer.UI.Commands
{
    public class ShowAboutFormCommand : ICommand
    {
        public void Execute()
        {
            new AboutForm().ShowDialog();
        }
    }
}
