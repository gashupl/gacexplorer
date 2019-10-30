using GacExplorer.CommandProxy;
using GacExplorer.Services.OperationResults;
using System;

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

        public ServiceOperationResult RegisterAssembly(string path)
        {
            try
            {
                var output = this.commandProxy.RegisterAssembly(path); 
                var outputParseResult = this.outputParserService.ParseRegisterOutput(output);

                return new ServiceOperationResult(outputParseResult.Result, outputParseResult.Message); 
            }
            catch (Exception ex)
            {
                return new GetAssemblyLinesOperationResult(OperationResult.Failed, "GlobalAssemblyCacheService.GetAssemblyLines failed", ex);
            }
        }
    }
}
