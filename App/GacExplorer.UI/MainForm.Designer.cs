namespace GacExplorer.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureGacutilLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridViewAssemblies = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCulture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPublicKeyToken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcessorArchitecture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openGacFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblAssemblyListCount = new System.Windows.Forms.Label();
            this.tlbPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnListAssemblies = new System.Windows.Forms.Button();
            this.lblFilter = new System.Windows.Forms.Label();
            this.textFilter = new System.Windows.Forms.TextBox();
            this.btnRegisterAssembly = new System.Windows.Forms.Button();
            this.addAssemblyFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.assembliesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAssemblies)).BeginInit();
            this.tlbPanel.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureGacutilLocationToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // configureGacutilLocationToolStripMenuItem
            // 
            this.configureGacutilLocationToolStripMenuItem.Name = "configureGacutilLocationToolStripMenuItem";
            this.configureGacutilLocationToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.configureGacutilLocationToolStripMenuItem.Text = "Configure Gacutil location";
            this.configureGacutilLocationToolStripMenuItem.Click += new System.EventHandler(this.ConfigureGacutilLocationToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // gridViewAssemblies
            // 
            this.gridViewAssemblies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewAssemblies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colVersion,
            this.colCulture,
            this.colPublicKeyToken,
            this.colProcessorArchitecture});
            this.gridViewAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewAssemblies.Location = new System.Drawing.Point(3, 43);
            this.gridViewAssemblies.Name = "gridViewAssemblies";
            this.gridViewAssemblies.Size = new System.Drawing.Size(794, 360);
            this.gridViewAssemblies.TabIndex = 1;
            this.gridViewAssemblies.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GridViewAssemblies_MouseClick);
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 300;
            // 
            // colVersion
            // 
            this.colVersion.DataPropertyName = "Version";
            this.colVersion.HeaderText = "Version";
            this.colVersion.Name = "colVersion";
            this.colVersion.ReadOnly = true;
            // 
            // colCulture
            // 
            this.colCulture.DataPropertyName = "Culture";
            this.colCulture.HeaderText = "Culture";
            this.colCulture.Name = "colCulture";
            this.colCulture.ReadOnly = true;
            // 
            // colPublicKeyToken
            // 
            this.colPublicKeyToken.DataPropertyName = "PublicKeyToken";
            this.colPublicKeyToken.HeaderText = "PublicKeyToken";
            this.colPublicKeyToken.Name = "colPublicKeyToken";
            this.colPublicKeyToken.ReadOnly = true;
            this.colPublicKeyToken.Width = 250;
            // 
            // colProcessorArchitecture
            // 
            this.colProcessorArchitecture.DataPropertyName = "ProcessorArchitecture";
            this.colProcessorArchitecture.HeaderText = "Architecture";
            this.colProcessorArchitecture.Name = "colProcessorArchitecture";
            this.colProcessorArchitecture.ReadOnly = true;
            // 
            // openGacFileDialog
            // 
            this.openGacFileDialog.FileName = "gacutil.exe";
            this.openGacFileDialog.Title = "Show me where the gacutil.exe is";
            // 
            // lblAssemblyListCount
            // 
            this.lblAssemblyListCount.AutoSize = true;
            this.lblAssemblyListCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAssemblyListCount.Location = new System.Drawing.Point(10, 406);
            this.lblAssemblyListCount.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lblAssemblyListCount.Name = "lblAssemblyListCount";
            this.lblAssemblyListCount.Size = new System.Drawing.Size(787, 20);
            this.lblAssemblyListCount.TabIndex = 2;
            this.lblAssemblyListCount.Text = "AssemblyListCount: ";
            // 
            // tlbPanel
            // 
            this.tlbPanel.ColumnCount = 1;
            this.tlbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlbPanel.Controls.Add(this.lblAssemblyListCount, 0, 2);
            this.tlbPanel.Controls.Add(this.gridViewAssemblies, 0, 1);
            this.tlbPanel.Controls.Add(this.panelTop, 0, 0);
            this.tlbPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlbPanel.Location = new System.Drawing.Point(0, 24);
            this.tlbPanel.Name = "tlbPanel";
            this.tlbPanel.RowCount = 3;
            this.tlbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlbPanel.Size = new System.Drawing.Size(800, 426);
            this.tlbPanel.TabIndex = 3;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnListAssemblies);
            this.panelTop.Controls.Add(this.lblFilter);
            this.panelTop.Controls.Add(this.textFilter);
            this.panelTop.Controls.Add(this.btnRegisterAssembly);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(794, 34);
            this.panelTop.TabIndex = 3;
            // 
            // btnListAssemblies
            // 
            this.btnListAssemblies.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnListAssemblies.Image = ((System.Drawing.Image)(resources.GetObject("btnListAssemblies.Image")));
            this.btnListAssemblies.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListAssemblies.Location = new System.Drawing.Point(140, 0);
            this.btnListAssemblies.Name = "btnListAssemblies";
            this.btnListAssemblies.Size = new System.Drawing.Size(140, 34);
            this.btnListAssemblies.TabIndex = 3;
            this.btnListAssemblies.Text = "List Assemblies";
            this.btnListAssemblies.UseVisualStyleBackColor = true;
            this.btnListAssemblies.Click += new System.EventHandler(this.btnListAssemblies_Click);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFilter.Location = new System.Drawing.Point(509, 0);
            this.lblFilter.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(63, 13);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "Filter List     ";
            // 
            // textFilter
            // 
            this.textFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.textFilter.Location = new System.Drawing.Point(572, 0);
            this.textFilter.Name = "textFilter";
            this.textFilter.Size = new System.Drawing.Size(222, 20);
            this.textFilter.TabIndex = 2;
            this.textFilter.TextChanged += new System.EventHandler(this.TbFilter_TextChanged);
            // 
            // btnRegisterAssembly
            // 
            this.btnRegisterAssembly.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRegisterAssembly.Image = ((System.Drawing.Image)(resources.GetObject("btnRegisterAssembly.Image")));
            this.btnRegisterAssembly.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegisterAssembly.Location = new System.Drawing.Point(0, 0);
            this.btnRegisterAssembly.Name = "btnRegisterAssembly";
            this.btnRegisterAssembly.Size = new System.Drawing.Size(140, 34);
            this.btnRegisterAssembly.TabIndex = 0;
            this.btnRegisterAssembly.Text = "Register Assembly";
            this.btnRegisterAssembly.UseVisualStyleBackColor = true;
            this.btnRegisterAssembly.Click += new System.EventHandler(this.BtnRegisterAssembly_Click);
            // 
            // addAssemblyFileDialog
            // 
            this.addAssemblyFileDialog.FileName = "openFileDialog1";
            this.addAssemblyFileDialog.Title = "Select assembly to be registered";
            // 
            // assembliesContextMenuStrip
            // 
            this.assembliesContextMenuStrip.Name = "assembliesContextMenuStrip";
            this.assembliesContextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlbPanel);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "GAC Explorer";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAssemblies)).EndInit();
            this.tlbPanel.ResumeLayout(false);
            this.tlbPanel.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureGacutilLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridView gridViewAssemblies;
        private System.Windows.Forms.OpenFileDialog openGacFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCulture;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPublicKeyToken;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessorArchitecture;
        private System.Windows.Forms.Label lblAssemblyListCount;
        private System.Windows.Forms.TableLayoutPanel tlbPanel;
        private System.Windows.Forms.OpenFileDialog addAssemblyFileDialog;
        private System.Windows.Forms.ContextMenuStrip assembliesContextMenuStrip;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Button btnRegisterAssembly;
        private System.Windows.Forms.TextBox textFilter;
        private System.Windows.Forms.Button btnListAssemblies;
    }
}

