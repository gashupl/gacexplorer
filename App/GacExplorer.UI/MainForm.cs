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

namespace GacExplorer.UI
{
    public partial class MainForm : Form
    {
        private IGacutilLocationService gacutilLocationService;
        private IGacutil gacUtilProxy; 

        public MainForm(IGacutilLocationService configurationService)
        {
            InitializeComponent();
            this.gacutilLocationService = configurationService; 
        }

        private void MainForm_Shown(object sender, EventArgs e)
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

        private void ConfigureGacutilLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowGacFileDialog(); 
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void ShowGacFileDialog()
        {
            var result = this.openGacFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fileLocation = this.openGacFileDialog.FileName;
                this.gacutilLocationService.Save(fileLocation);
            }
            this.openGacFileDialog.Dispose();
        }


    }
}
