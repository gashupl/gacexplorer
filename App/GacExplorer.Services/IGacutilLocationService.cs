using GacExplorer.Services.OperationResults;

namespace GacExplorer.Services
{
    public interface IGacutilLocationService
    {
        ServiceOperationResult Save(string fileLocation);

        GacutilLocationReadResult Read();

        bool FileExists(string location); 
    }
}
