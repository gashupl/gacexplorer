namespace GacExplorer.CommandProxy
{
    public interface IGacutil
    {
        string ListAssemblies();

        string RegisterAssembly(string path);

        string UnregisterAssembly(string name);
    }
}
