using System;

namespace GacExplorer.Services.OperationResults
{
    public class ServiceOperationResult
    {
        public ServiceOperationResult(OperationResult result, string message = "")
        {
            Result = result;
            Message = message; 
        }

        public ServiceOperationResult(OperationResult result, string message, Exception exception)
        {
            Result = result;
            @Exception = Exception; 
            Message = message;
        }

        public OperationResult Result { get; }
        public string Message { get;  }

        public Exception Exception { get; }

    }

    public enum OperationResult
    {
        Success,
        SuccessWithErrors, 
        Failed, 

    }
}
