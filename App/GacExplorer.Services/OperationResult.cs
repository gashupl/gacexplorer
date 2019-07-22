using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GacExplorer.Services
{
    public class ServiceOperationResult
    {
        public ServiceOperationResult(OperationResult result, string message)
        {
            Result = result;
            Message = message; 
        }
        public OperationResult Result { get; }
        public string Message { get;  }

    }

    public enum OperationResult
    {
        Success,
        SuccessWithErrors, 
        Failed, 

    }
}
