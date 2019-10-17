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
            try
            {
                var output = this.commandProxy.ListAssemblies();
                var outputParseResult = this.outputParserService.ParseListOutput(output);

                return new GetAssemblyLinesOperationResult(outputParseResult.Result)
                {
                    AssemblyLines = outputParseResult.AssemblyLines
                };
            }
            catch (Exception ex)
            {
                return new GetAssemblyLinesOperationResult(OperationResult.Failed, "GlobalAssemblyCacheService.GetAssemblyLines failed", ex); 
       
            }



        }
    }
}
