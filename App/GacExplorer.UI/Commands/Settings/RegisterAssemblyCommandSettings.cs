using GacExplorer.CommandProxy;
using GacExplorer.Logging;
using GacExplorer.Services;
using GacExplorer.UI.Commands.Base;
using GacExplorer.UI.Wrappers;

namespace GacExplorer.UI.Commands.Settings
{
    public class RegisterAssemblyCommandSettings
    {
        public IGlobalAssemblyCacheService GacService { get; set; }
        public IGacutil GacUtilProxy { get; set; }
        public ICommand ListAssembliesCommand { get; set; }
        public IOpenFileDialog AddAssemblyFileDialog { get; set; }
        public IGacutilOutputParserService ParserService { get; set; }
        public ILog Log { get; set; }
    }
}
