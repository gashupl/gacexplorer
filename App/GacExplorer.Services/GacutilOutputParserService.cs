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
        }

        public GacutilOutputParserResult ParseListOutput(string output)
        {
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
            return this.ParseOutput(output, "Assembly successfully added to the cache");
        }

        public ServiceOperationResult ParseUnregisterOutput(string output)
        {
            return this.ParseOutput(output, "Number of assemblies uninstalled = 1"); 
        }

        private ServiceOperationResult ParseOutput(string output, string requiredSuccessText)
        {
            if (String.IsNullOrWhiteSpace(output))
            {
                return new ServiceOperationResult(OperationResult.Failed, $"{MethodBase.GetCurrentMethod().Name} operation failed. Empty output string");
            }
            else
            {
                string successText = requiredSuccessText;
                if (output.Contains(successText))
                {
                    return new ServiceOperationResult(OperationResult.Success, successText);
                }
                else
                {
                    return new ServiceOperationResult(OperationResult.Failed, output);
                }
            }
        }
    }
}
