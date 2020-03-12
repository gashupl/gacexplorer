using System;
using System.Windows.Forms;

namespace GacExplorer.UI.Wrappers
{
    class DataGridViewWrapper : IDataGridView
    {
        private DataGridView gridView; 
        public DataGridViewWrapper(DataGridView gridView)
        {
            this.gridView = gridView; 
        }

        public object DataSource
        {
            get => this.gridView.DataSource;
            set => this.DataSource = value; 
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }
    }
}
