using System.Collections.Generic;
using System.Windows.Forms;
using GacExplorer.CommandProxy;
using GacExplorer.Logging;
using GacExplorer.Services;
using GacExplorer.Services.DTO;

namespace GacExplorer.UI.Commands.Settings
{
    public class ListAssembliesCommandSettings
    {
        public IGacutilLocationService GacutilLocationService { get; set; }
        public IGacutilOutputParserService ParserService { get; set; }
        public IGlobalAssemblyCacheService GacService { get; set; }
        public IGacutil GacUtilProxy { get; set; }
        public List<AssemblyLineDto> AssemblyLineList { get; set; }
        public ILog Log { get; set; }

        public ShowGacFileDialogCommand ShowGacFileDialogCommand { get; set; }
        public InitializeGacUtilProxyCommand InitializeGacUtilProxyCommand { get; set; }

        public DataGridView GridViewAssemblies { get; set; }
        public Label LblAssemblyListCount { get; set; }
    }
}
