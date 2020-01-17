using System.Windows.Forms;
using GacExplorer.CommandProxy;
using GacExplorer.Logging;
using GacExplorer.Services;
using GacExplorer.UI.Commands.Base;

namespace GacExplorer.UI.Commands.Settings
{
    public class GridViewAssembliesClickCommandSettings
    {
        public IGlobalAssemblyCacheService GacService { get; set; }
        public IGacutil GacUtilProxy { get; set; }
        public IGacutilOutputParserService ParserService { get; set; }
        public ICommand ListAssembliesCommand { get; set; }
        public ILog Log { get; set; }
        public DataGridView GridViewAssemblies { get; set; }
        public MouseEventArgs MouseEventArguments { get; set; }
}
}
