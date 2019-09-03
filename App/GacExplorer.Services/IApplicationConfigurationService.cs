using GacExplorer.Services.OperationResults;
using GacExplorer.Services.Wrappers;
using System.Configuration;

namespace GacExplorer.Services
{
    public interface IApplicationConfigurationService
    {
        IConfiguration GetConfiguration();

        ServiceOperationResult SaveConfiguration(IConfiguration configuration);

        ServiceOperationResult RefreshConfigurationSettings();

        KeyValueConfigurationCollection GetSettings(IConfiguration configuration);
    }
}
