using GacExplorer.Services.DTO;
using GacExplorer.Services.OperationResults;
using System.Collections.Generic;

namespace GacExplorer.Services
{
    public interface IGlobalAssemblyCacheService
    {
        GetAssemblyLinesOperationResult GetAssemblyLines(); 
    }
}
