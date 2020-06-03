using GacExplorer.UI.Wrappers;

namespace GacExplorer.UI.Commands.Base
{
    public abstract class Command
    {
        protected IMessageBox messageBox;
        public Command(IMessageBox messageBox)
        {
            this.messageBox = messageBox;
        }

        public Command()
        {
        }

        public static void Invoke(ICommand command)
        {
            command.Execute();
        }
    }
}
