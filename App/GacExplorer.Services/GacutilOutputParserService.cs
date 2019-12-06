using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using GacExplorer.Logging;
using GacExplorer.Services.DTO;
using GacExplorer.Services.OperationResults;

namespace GacExplorer.Services
{
    public class GacutilOutputParserService : ServiceBase, IGacutilOutputParserService
    {

        public GacutilOutputParserService(ILog log) : base(log)
        {
            this.log.Trace($"{nameof(GacutilOutputParserService)} initialized");
        }

        public GacutilOutputParserResult ParseListOutput(string output)
        {
            this.log.Trace($"{nameof(ParseListOutput)} method executed with parameter path: {output}");
            if (String.IsNullOrWhiteSpace(output))
            {
                return new GacutilOutputParserResult(OperationResult.Failed, "GacutilOutputParserService.ParseListOutput operation failed. Empty output string");
            }

            var assemblyLinesList = new List<AssemblyLineDto>();
            string[] outputLines = Regex.Split(output, "\r\n|\r|\n"); //Split every line
            foreach (var line in outputLines)
            {
                string[] words = line.Split(','); //Not using Regex becuase it is not necessary and slower
                if (words.Length == 5)
                {
                    var assemblyLine = new AssemblyLineDto()
                    {
                        Name = words[0].Trim(),
                        Version = words[1].Replace(" Version=", String.Empty).Trim(),
                        Culture = words[2].Replace(" Culture=", String.Empty).Trim(),
                        PublicKeyToken = words[3].Replace(" PublicKeyToken=", String.Empty).Trim(),
                        ProcessorArchitecture = words[4].Replace(" processorArchitecture=", String.Empty).Trim()
                    };

                    if (assemblyLine.IsValid())
                    {
                        assemblyLinesList.Add(assemblyLine);
                    }
                }
            }

            if (assemblyLinesList.Count == 0)
            {
                return new GacutilOutputParserResult(OperationResult.Failed, "GacutilOutputParserService.ParseListOutput operation failed. No valid assembly lines found");
            }
            else
            {
                return new GacutilOutputParserResult(OperationResult.Success)
                {
                    AssemblyLines = assemblyLinesList
                };
            }
        }

        public ServiceOperationResult ParseRegisterOutput(string output)
        {
            this.log.Trace($"{nameof(ParseRegisterOutput)} method executed with parameter path: {output}");
            return this.ParseOutput(output, "Assembly successfully added to the cache");
        }

        public ServiceOperationResult ParseUnregisterOutput(string output)
        {
            this.log.Trace($"{nameof(ParseUnregisterOutput)} method executed with parameter path: {output}");
            return this.ParseOutput(output, "Number of assemblies uninstalled = 1"); 
        }

        private ServiceOperationResult ParseOutput(string output, string requiredSuccessText)
        {
            this.log.Trace($"{nameof(ParseOutput)} method executed with parameters path: {output}, requiredSuccessText: {requiredSuccessText}");
            if (String.IsNullOrWhiteSpace(output))
            {
                this.log.Warning($"Empty output");
                return new ServiceOperationResult(OperationResult.Failed, $"{MethodBase.GetCurrentMethod().Name} operation failed. Empty output string");
            }
            else
            {
                string successText = requiredSuccessText;
                if (output.Contains(successText))
                {
                    this.log.Info($"Output contains the following text: {successText}"); 
                    return new ServiceOperationResult(OperationResult.Success, successText);
                }
                else
                {
                    this.log.Warning($"Output does not contain the following text: {successText}");
                    return new ServiceOperationResult(OperationResult.Failed, output);
                }
            }
        }
    }
}
