using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GacExplorer.CommandProxy;
using GacExplorer.Logging;
using GacExplorer.Services;
using GacExplorer.UI.Commands.Base;

namespace GacExplorer.UI.Commands.Settings
{
    public class RegisterAssemblyCommandSettings
    {
        public IGlobalAssemblyCacheService GacService { get; set; }
        public IGacutil GacUtilProxy { get; set; }
        public ICommand ListAssembliesCommand { get; set; }
        public OpenFileDialog AddAssemblyFileDialog { get; set; }
        public IGacutilOutputParserService ParserService { get; set; }
        public ILog Log { get; set; }
    }
}
