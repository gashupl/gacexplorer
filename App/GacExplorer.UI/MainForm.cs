using GacExplorer.Services;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using GacExplorer.Services.OperationResults;
using GacExplorer.CommandProxy;
using GacExplorer.Services.DTO;
using System.Linq;
using System.Collections.Generic;
using GacExplorer.Logging;
using GacExplorer.UI.Commands;
using GacExplorer.UI.Commands.Base;
using GacExplorer.UI.Properties;
using GacExplorer.UI.Commands.Settings;
using GacExplorer.UI.Wrappers;

namespace GacExplorer.UI
{
    public partial class MainForm : Form
    {
        private IGacutilLocationService gacutilLocationService;
        private IGacutilOutputParserService parserService;
        private IGlobalAssemblyCacheService gacService; 
        private IGacutil gacUtilProxy;
        private ILog log;

        private ShowGacFileDialogCommand showGacFileDialogCommand;
        private InitializeGacUtilProxyCommand initializeGacUtilProxyCommand;
        private ListAssembliesCommand listAssembliesCommand;
        private ApplicationExitCommand applicationExitCommand;
        private ShowAboutFormCommand showAboutFormCommand;

        private MessageBoxWrapper messageBox = new MessageBoxWrapper();

        public MainForm(IGacutilLocationService configurationService, IGacutilOutputParserService parserService, IGacutil gacUtilProxy, ILog log)
        {
            InitializeComponent();

            
            this.log = log;
            this.gacUtilProxy = gacUtilProxy; 
            this.gacutilLocationService = configurationService;
            this.parserService = parserService;

            var fileDialogWrapper = new OpenFileDialogWrapper(this.openGacFileDialog); 
            this.showGacFileDialogCommand = new ShowGacFileDialogCommand(fileDialogWrapper, this.gacutilLocationService, this.gacUtilProxy, this.messageBox);
            this.initializeGacUtilProxyCommand = new InitializeGacUtilProxyCommand(this.showGacFileDialogCommand, this.gacutilLocationService, this.gacUtilProxy);
            this.listAssembliesCommand = new ListAssembliesCommand(new ListAssembliesCommandSettings()
            {
                GacutilLocationService = this.gacutilLocationService, 
                ParserService = this.parserService, 
                GacService = this.gacService, 
                GacUtilProxy = this.gacUtilProxy,
                Log = this.log, 
                ShowGacFileDialogCommand = this.showGacFileDialogCommand, 
                InitializeGacUtilProxyCommand = this.initializeGacUtilProxyCommand,
                GridViewAssemblies = this.gridViewAssemblies, 
                LblAssemblyListCount = this.lblAssemblyListCount
            });

            this.applicationExitCommand = new ApplicationExitCommand(new ApplicationWrapper());
            this.showAboutFormCommand = new ShowAboutFormCommand(); 
        }

        #region EventHandlers
        private void MainForm_Shown(object sender, EventArgs e)
        {
            Command.Invoke(listAssembliesCommand);
        }

        private void ConfigureGacutilLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Command.Invoke(showGacFileDialogCommand); 
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Command.Invoke(applicationExitCommand); 
        }

        private void btnListAssemblies_Click(object sender, EventArgs e)
        {
            Command.Invoke(listAssembliesCommand);
        }

        private void BtnRegisterAssembly_Click(object sender, EventArgs e)
        {
            Command.Invoke(new RegisterAssemblyCommand(new RegisterAssemblyCommandSettings()
            {
                GacService = this.gacService,
                GacUtilProxy = this.gacUtilProxy,
                ListAssembliesCommand = this.listAssembliesCommand,
                AddAssemblyFileDialog = this.addAssemblyFileDialog,
                ParserService = this.parserService,
                Log = this.log
            },
                this.messageBox)); 
        }

        private void BtnRemoveAssembly_Click(object sender, EventArgs e)
        {
            Command.Invoke(new RemoveAssemblyCommand(new RemoveAssemblyCommandSettings()
            {
                GacService = this.gacService,
                GacUtilProxy = this.gacUtilProxy,
                ParserService = this.parserService,
                ListAssembliesCommand = this.listAssembliesCommand,
                Log = this.log,
                GridViewAssemblies = this.gridViewAssemblies
            }, 
                this.messageBox));
        }

        private void TbFilter_TextChanged(object sender, EventArgs e)
        {
            var gridViewWrapper = new DataGridViewWrapper(this.gridViewAssemblies); 
            Command.Invoke(new FilterAssemblyGridCommand(gridViewWrapper, this.textFilter));
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Command.Invoke(showAboutFormCommand);
        }
        #endregion


    }
}