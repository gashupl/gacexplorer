using GacExplorer.Services.OperationResults;

namespace GacExplorer.Services
{
    public interface IGlobalAssemblyCacheService
    {
        GetAssemblyLinesOperationResult GetAssemblyLines();

        ServiceOperationResult RegisterAssembly(string path); 
    }
}
