using GacExplorer.Services.DTO;
using System.Collections.Generic;

namespace GacExplorer.Services
{
    public interface IGlobalAssemblyCacheService
    {
        List<AssemblyLineDto> GetAssemblyLines(); 
    }
}
