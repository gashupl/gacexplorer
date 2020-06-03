namespace GacExplorer.UI.Wrappers
{
    public interface IDataGridView
    {
        object DataSource { get; set; }

        void Refresh(); 
    }
}
