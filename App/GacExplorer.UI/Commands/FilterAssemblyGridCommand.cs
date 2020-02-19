using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using GacExplorer.Services.DTO;
using GacExplorer.UI.Commands.Base;

namespace GacExplorer.UI.Commands
{
    public class FilterAssemblyGridCommand : ICommand
    {
        private DataGridView gridViewAssemblies;
        private TextBox textFilter;

        public FilterAssemblyGridCommand(DataGridView gridViewAssemblies, TextBox textFilter)
        {
            this.gridViewAssemblies = gridViewAssemblies;
            this.textFilter = textFilter;

        }
        public void Execute()
        {
            if (this.gridViewAssemblies.DataSource is BindingSource data)
            {
                if (data.DataSource is BindingList<AssemblyLineDto> source)
                {
                    if (this.textFilter.Text.Length > 2)
                    {
                        var filteredBindingList = new BindingList<AssemblyLineDto>(source.Where(x => x.Name.ToLower().Contains(this.textFilter.Text.ToLower())).ToList());
                        var bindingList = new BindingList<AssemblyLineDto>(filteredBindingList);
                        this.gridViewAssemblies.DataSource = new BindingSource(bindingList, null);
                    }
                    else
                    {
                        var bindingList = new BindingList<AssemblyLineDto>(Program.AssemblyLineList);
                        this.gridViewAssemblies.DataSource = new BindingSource(bindingList, null);
                    }
                    this.gridViewAssemblies.Refresh();
                }

            }
        }
    }
}
