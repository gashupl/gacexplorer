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
        public MainForm()
        {
            InitializeComponent();
        }

        private void ConfigureGacutilLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = this.openGacFileDialog.ShowDialog(); 
            if (result == DialogResult.OK)
            {
              //  result.T
            }
            this.openGacFileDialog.Dispose(); 


        }
    }
}
