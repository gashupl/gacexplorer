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
        private IGacutilOutputParserService outputParserService; 
        public GlobalAssemblyCacheService(IGacutil commandProxy, IGacutilOutputParserService outputParserService)
        {
            this.commandProxy = commandProxy;
            this.outputParserService = outputParserService; 
        }

        public GetAssemblyLinesOperationResult GetAssemblyLines()
        {
            var gacutilOutput = this.commandProxy.ListAssemblies();
            return new GetAssemblyLinesOperationResult(OperationResult.Success); 

        }
    }
}
