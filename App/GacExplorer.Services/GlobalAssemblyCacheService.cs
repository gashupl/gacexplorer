using GacExplorer.CommandProxy;
using GacExplorer.Services.DTO;
using GacExplorer.Services.OperationResults;
using System;
using System.Linq;
using GacExplorer.Logging;

namespace GacExplorer.Services
{
    public class GlobalAssemblyCacheService : ServiceBase, IGlobalAssemblyCacheService
    {
        private IGacutil commandProxy;
        private IGacutilOutputParserService outputParserService; 
        public GlobalAssemblyCacheService(IGacutil commandProxy, IGacutilOutputParserService outputParserService, ILog log) : base(log)
        {
            this.log.Trace($"{nameof(GlobalAssemblyCacheService)} initialized");
            this.commandProxy = commandProxy;
            this.outputParserService = outputParserService; 
        }

        public GetAssemblyLinesOperationResult GetAssemblyLines()
        {
            this.log.Trace($"{nameof(GetAssemblyLinesOperationResult)} method executed");
            try
            {
                var output = this.commandProxy.ListAssemblies();
                var outputParseResult = this.outputParserService.ParseListOutput(output);


                return new GetAssemblyLinesOperationResult(outputParseResult.Result)
                {
                    AssemblyLines = outputParseResult.AssemblyLines?.OrderBy(a => a.Name).ToList<AssemblyLineDto>() 
                };
            }
            catch (Exception ex)
            {
                log.Error(ex, $"{nameof(GetAssemblyLines)} failed");
                return new GetAssemblyLinesOperationResult(OperationResult.Failed, "GlobalAssemblyCacheService.GetAssemblyLines failed", ex); 
            }
        }

        public ServiceOperationResult RegisterAssembly(string path)
        {
            this.log.Trace($"{nameof(RegisterAssembly)} method executed with parameter path: {path}");
            try
            {
                var output = this.commandProxy.RegisterAssembly(path); 
                var outputParseResult = this.outputParserService.ParseRegisterOutput(output);

                return new ServiceOperationResult(outputParseResult.Result, outputParseResult.Message); 
            }
            catch (Exception ex)
            {
                log.Error(ex, $"{nameof(RegisterAssembly)} failed");
                return new GetAssemblyLinesOperationResult(OperationResult.Failed, "GlobalAssemblyCacheService.GetAssemblyLines failed", ex);
            }
        }

        public ServiceOperationResult UnregisterAssembly(string path)
        {
            this.log.Trace($"{nameof(UnregisterAssembly)} method executed with parameter path: {path}");
            try
            {
                var output = this.commandProxy.UnregisterAssembly(path);
                var outputParseResult = this.outputParserService.ParseUnregisterOutput(output);

                return new ServiceOperationResult(outputParseResult.Result, outputParseResult.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex, $"{nameof(UnregisterAssembly)} failed"); 
                return new GetAssemblyLinesOperationResult(OperationResult.Failed, "GlobalAssemblyCacheService.GetAssemblyLines failed", ex);
            }
        }
    }
}
