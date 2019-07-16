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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
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
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAssemblies)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
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
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
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
            this.gridViewAssemblies.Location = new System.Drawing.Point(0, 24);
            this.gridViewAssemblies.Name = "gridViewAssemblies";
            this.gridViewAssemblies.Size = new System.Drawing.Size(800, 426);
            this.gridViewAssemblies.TabIndex = 1;
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 300;
            // 
            // colVersion
            // 
            this.colVersion.HeaderText = "Version";
            this.colVersion.Name = "colVersion";
            this.colVersion.ReadOnly = true;
            // 
            // colCulture
            // 
            this.colCulture.HeaderText = "Culture";
            this.colCulture.Name = "colCulture";
            this.colCulture.ReadOnly = true;
            // 
            // colPublicKeyToken
            // 
            this.colPublicKeyToken.HeaderText = "PublicKeyToken";
            this.colPublicKeyToken.Name = "colPublicKeyToken";
            this.colPublicKeyToken.ReadOnly = true;
            this.colPublicKeyToken.Width = 250;
            // 
            // colProcessorArchitecture
            // 
            this.colProcessorArchitecture.HeaderText = "Architecture";
            this.colProcessorArchitecture.Name = "colProcessorArchitecture";
            this.colProcessorArchitecture.ReadOnly = true;
            // 
            // openGacFileDialog
            // 
            this.openGacFileDialog.FileName = "gacutil.exe";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridViewAssemblies);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "GAC Explorer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAssemblies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureGacutilLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridView gridViewAssemblies;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCulture;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPublicKeyToken;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessorArchitecture;
        private System.Windows.Forms.OpenFileDialog openGacFileDialog;
    }
}

