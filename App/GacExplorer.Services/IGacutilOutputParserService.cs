using GacExplorer.Services.OperationResults;

namespace GacExplorer.Services
{
    public interface IGacutilOutputParserService
    {
        GacutilOutputParserResult ParseListOutput(string output);

        ServiceOperationResult ParseRegisterOutput(string output); 
    }
}
