namespace GacExplorer.UI.Commands.Base
{
    public abstract class Command
    {
        public static void Invoke(ICommand command)
        {
            command.Execute();
        }
    }
}
