using GacExplorer.Services.Wrappers;
using System.Configuration;

namespace GacExplorer.Services
{
    public interface IApplicationConfigurationService
    {
        ConfigurationWrapper GetConfiguration();

        ServiceOperationResult SaveConfiguration(ConfigurationWrapper configuration);

        ServiceOperationResult RefreshConfigurationSettings();

        KeyValueConfigurationCollection GetSettings(ConfigurationWrapper configuration);
    }
}
