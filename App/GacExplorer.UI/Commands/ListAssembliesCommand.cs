using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GacExplorer.CommandProxy;
using GacExplorer.Logging;
using GacExplorer.Services;
using GacExplorer.Services.DTO;
using GacExplorer.UI.Commands.Base;
using GacExplorer.UI.Commands.Settings;

namespace GacExplorer.UI.Commands
{
    public class ListAssembliesCommand : ICommand
    {
        private IGacutilLocationService gacutilLocationService;
        private IGacutilOutputParserService parserService;
        private IGlobalAssemblyCacheService gacService;
        private IGacutil gacUtilProxy;
        private ILog log;

        private ShowGacFileDialogCommand showGacFileDialogCommand;
        private InitializeGacUtilProxyCommand initializeGacUtilProxyCommand;

        private DataGridView gridViewAssemblies;
        private Label lblAssemblyListCount;

        public ListAssembliesCommand(ListAssembliesCommandSettings settings)
        {
            gacutilLocationService = settings.GacutilLocationService;
            parserService = settings.ParserService;
            gacService = settings.GacService;
            gacUtilProxy = settings.GacUtilProxy;
            log = settings.Log;

            showGacFileDialogCommand = settings.ShowGacFileDialogCommand;
            initializeGacUtilProxyCommand = settings.InitializeGacUtilProxyCommand;

            gridViewAssemblies = settings.GridViewAssemblies;
            lblAssemblyListCount = settings.LblAssemblyListCount;
        }
        public void Execute()
        {
            if (String.IsNullOrEmpty(gacUtilProxy.Location))
            {
                Command.Invoke(initializeGacUtilProxyCommand);
            }

            if (this.gacService == null)
            {
                this.gacService = new GlobalAssemblyCacheService(this.gacUtilProxy, this.parserService, log);
            }

            Program.AssemblyLineList = gacService.GetAssemblyLines().AssemblyLines;
            if (Program.AssemblyLineList != null)
            {
                var bindingList = new BindingList<AssemblyLineDto>(Program.AssemblyLineList);
                this.gridViewAssemblies.DataSource = new BindingSource(bindingList, null);
                this.lblAssemblyListCount.Text += Program.AssemblyLineList.Count.ToString();
            }
            else
            {
                Command.Invoke(this.showGacFileDialogCommand);
                if (this.showGacFileDialogCommand.ShowGacFileDialogResult == DialogResult.OK)
                {
                    Command.Invoke(this); 
                }
            }
        }
    }
}
