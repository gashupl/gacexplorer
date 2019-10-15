using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using GacExplorer.Services.DTO;
using GacExplorer.Services.OperationResults;

namespace GacExplorer.Services
{
    public class GacutilOutputParserService : IGacutilOutputParserService
    {
        public GacutilOutputParserResult ParseListOutput(string output)
        {
            if (String.IsNullOrWhiteSpace(output))
            {
                return new GacutilOutputParserResult(OperationResult.Failed, "GacutilOutputParserService.ParseListOutput operation failed. Empty output string"); 
            }

            var assemblyLinesList = new List<AssemblyLineDto>();

            string[] outputLines = Regex.Split(output, "\r\n|\r|\n"); //Split every line
            foreach(var line in outputLines)
            {
                string[] words = line.Split(','); //Not using Regex becuase it is not necessary and slower
                if(words.Length == 5)
                {
                    //TODO: For every line meeting above mentioned condition - try to convert it into AssemblyLineDto
                }
            }

            throw new NotImplementedException(); 
        }
    }
}
