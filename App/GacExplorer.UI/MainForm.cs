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

namespace GacExplorer.UI
{
    public partial class MainForm : Form
    {
        private IConfigurationService configurationService; 

        public MainForm(IConfigurationService configurationService)
        {
            InitializeComponent();
            this.configurationService = configurationService; 
        }

        private void ConfigureGacutilLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = this.openGacFileDialog.ShowDialog(); 
            if (result == DialogResult.OK)
            {
                var fileLocation = this.openGacFileDialog.FileName;
                this.configurationService.SaveGacutilLocation(fileLocation); 
            }
            this.openGacFileDialog.Dispose(); 


        }
    }
}
