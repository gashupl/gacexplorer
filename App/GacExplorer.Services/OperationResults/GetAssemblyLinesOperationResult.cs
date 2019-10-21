using GacExplorer.Services.DTO;
using System;
using System.Collections.Generic;

namespace GacExplorer.Services.OperationResults
{
    public class GetAssemblyLinesOperationResult : ServiceOperationResult
    {
        public List<AssemblyLineDto> AssemblyLines { get; set; }

        public GetAssemblyLinesOperationResult(OperationResult result, string message = "") : base(result, message)
        {
        }

        public GetAssemblyLinesOperationResult(OperationResult result, string message, Exception exception) : base(result, message, exception)
        {
        }
    }
}
