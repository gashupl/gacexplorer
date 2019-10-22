using GacExplorer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GacExplorer.Services.OperationResults;
using GacExplorer.CommandProxy;
using GacExplorer.Services.DTO;

namespace GacExplorer.UI
{
    public partial class MainForm : Form
    {
        private IGacutilLocationService gacutilLocationService;
        private IGacutilOutputParserService parserService;
        private IGlobalAssemblyCacheService gacService; 
        private IGacutil gacUtilProxy; 

        public MainForm(IGacutilLocationService configurationService, IGacutilOutputParserService parserService)
        {
            InitializeComponent();
            this.gacutilLocationService = configurationService;
            this.parserService = parserService; 
        }

        #region EventHandlers
        private void MainForm_Shown(object sender, EventArgs e)
        {
            ListAssemblies(); 
        }

        private void ConfigureGacutilLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowGacFileDialog(); 
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void ListAssembliesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListAssemblies();
        }
        #endregion

        #region Private methods
        private DialogResult ShowGacFileDialog()
        {
            var result = this.openGacFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fileLocation = this.openGacFileDialog.FileName;
                this.gacutilLocationService.Save(fileLocation);
                this.gacUtilProxy = new Gacutil(fileLocation);
              
            }
            this.openGacFileDialog.Dispose();
            return result;
        }

        private void InitializeGacUtilProxy()
        {
            var result = this.gacutilLocationService.Read();
            if (result.Result == OperationResult.Success)
            {
                var location = result.Location;
                if (this.gacutilLocationService.FileExists(location))
                {
                    this.gacUtilProxy = new Gacutil(location);
                }
                else
                {
                    ShowGacFileDialog();
                }
            }
        }

        private void ListAssemblies()
        {
            if (gacUtilProxy == null)
            {
                InitializeGacUtilProxy();
            }

            this.gacService = new GlobalAssemblyCacheService(this.gacUtilProxy, this.parserService);
            var assemblyLineList = gacService.GetAssemblyLines().AssemblyLines; 
            if(assemblyLineList != null)
            {
                var bindingList = new BindingList<AssemblyLineDto>(assemblyLineList);
                this.gridViewAssemblies.DataSource = new BindingSource(bindingList, null);
                this.lblAssemblyListCount.Text += assemblyLineList.Count.ToString(); 
            }
            else
            {
                if(ShowGacFileDialog() == DialogResult.OK)
                {
                    ListAssemblies();
                }

            }

        }
        #endregion

    }
}
