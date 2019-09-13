using System;

namespace GacExplorer.Services.OperationResults
{
    public class GacutilLocationReadResult : ServiceOperationResult
    {
        public string Location { get; set; }

        #region Constructors
        public GacutilLocationReadResult(OperationResult result, string message = "") : base(result, message)
        {
        }

        public GacutilLocationReadResult(OperationResult result, string message, Exception exception) : base(result, message, exception)
        {
        }
        #endregion
    }
}
