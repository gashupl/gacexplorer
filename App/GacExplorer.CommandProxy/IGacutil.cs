using System.Diagnostics.CodeAnalysis;

namespace GacExplorer.CommandProxy
{
    public interface IGacutil
    {
        string Location { get; set; }

        string ListAssemblies();

        string RegisterAssembly(string path);

        string UnregisterAssembly(string name);
    }
}
