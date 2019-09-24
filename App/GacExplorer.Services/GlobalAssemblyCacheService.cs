using GacExplorer.CommandProxy;
using GacExplorer.Services.DTO;
using GacExplorer.Services.OperationResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GacExplorer.Services
{
    public class GlobalAssemblyCacheService : IGlobalAssemblyCacheService
    {
        private IGacutil commandProxy; 
        public GlobalAssemblyCacheService(IGacutil commandProxy)
        {
            this.commandProxy = commandProxy; 
        }

        public GetAssemblyLinesOperationResult GetAssemblyLines()
        {
            throw new NotImplementedException(); 
        }
    }
}
