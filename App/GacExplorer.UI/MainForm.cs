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

namespace GacExplorer.UI
{
    public partial class MainForm : Form
    {
        private IGacutilLocationService gacutilLocationService;
        private IGacutilOutputParserService parserService;
        private IGlobalAssemblyCacheService gacService; 
        private IGacutil gacUtilProxy;
        private List<AssemblyLineDto> assemblyLineList;
        private ILog log; 

        public MainForm(IGacutilLocationService configurationService, IGacutilOutputParserService parserService, ILog log)
        {
            InitializeComponent();
            this.log = log; 
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

        private void btnListAssemblies_Click(object sender, EventArgs e)
        {
            ListAssemblies();
        }

        private void BtnRegisterAssembly_Click(object sender, EventArgs e)
        {
            if (this.gacUtilProxy == null)
            {
                MessageBox.Show("You need to configure localization of GacUtil.exe tool before performing registration"); 
            }
            else
            {
                var result = this.addAssemblyFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                { 
                    if(this.gacService == null)
                    {
                        gacService = new GlobalAssemblyCacheService(this.gacUtilProxy, this.parserService, log);
                    }
                    var response = this.gacService.RegisterAssembly(this.addAssemblyFileDialog.FileName);
                    if (response.Result == OperationResult.Success)
                    {
                        MessageBox.Show("Assembly successfully registered in GAC");
                        ListAssemblies(); 
                    }
                    else
                    {
                        MessageBox.Show($"Error when registering assembly in GAC: {response.Message}");
                    }
                }
            }
        }

        private void GridViewAssemblies_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.gridViewAssemblies.SelectedRows.Count == 1)
                {
                    var selectedRow = this.gridViewAssemblies.SelectedRows[0];
                    var hitRowIndex = this.gridViewAssemblies.HitTest(e.X, e.Y).RowIndex;
                    int selectedRowIndex = selectedRow.Index;
                    if (hitRowIndex == selectedRowIndex)
                    {
                        var assemblyName = Convert.ToString(selectedRow.Cells[0].Value);
                        var result = MessageBox.Show($"Assembly '{assemblyName}' will be removed from Global Assembly Cache. Continue?",
                                     "Please confirm uninstallaiton",
                                     MessageBoxButtons.YesNo);
                        if(result == DialogResult.Yes)
                        {
                            if (this.gacUtilProxy == null)
                            {
                                MessageBox.Show("You need to configure localization of GacUtil.exe tool before performing registration");
                            }
                            else
                            {
                                if (this.gacService == null)
                                {
                                    gacService = new GlobalAssemblyCacheService(this.gacUtilProxy, this.parserService, log);
                                }
                                var response = this.gacService.UnregisterAssembly(assemblyName);
                                if (response.Result == OperationResult.Success)
                                {
                                    MessageBox.Show("Assembly successfully unregistered from GAC");
                                    ListAssemblies(); 
                                }
                                else
                                {
                                    MessageBox.Show($"Error when unregistering assembly from GAC: {response.Message}");
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select single assembly to be uninstalled from GAC");
                }
            }
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

            if(this.gacService == null)
            {
                this.gacService = new GlobalAssemblyCacheService(this.gacUtilProxy, this.parserService, log);
            }

            this.assemblyLineList = gacService.GetAssemblyLines().AssemblyLines; 
            if(this.assemblyLineList != null)
            {
                var bindingList = new BindingList<AssemblyLineDto>(this.assemblyLineList);
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

        private void TbFilter_TextChanged(object sender, EventArgs e)
        {
            if (this.gridViewAssemblies.DataSource is BindingSource data)
            {
                if (data.DataSource is BindingList<AssemblyLineDto> source)
                {
                    if (this.textFilter.Text.Length > 2)
                    {
                        var filteredBindingList = new BindingList<AssemblyLineDto>(source.Where(x => x.Name.Contains(this.textFilter.Text)).ToList());
                        var bindingList = new BindingList<AssemblyLineDto>(filteredBindingList);
                        this.gridViewAssemblies.DataSource = new BindingSource(bindingList, null);
                    }
                    else
                    {
                        var bindingList = new BindingList<AssemblyLineDto>(assemblyLineList);
                        this.gridViewAssemblies.DataSource = new BindingSource(bindingList, null);
                    }
                    this.gridViewAssemblies.Refresh();
                }

            }

        }


        #endregion


    }
}