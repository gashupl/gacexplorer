using System.Configuration;

namespace GacExplorer.Services
{
    public interface IApplicationConfigurationService
    {
        Configuration GetConfiguration();

        void SaveConfiguration(Configuration configuration);

        void RefreshConfigurationSettings();

        KeyValueConfigurationCollection GetSettings(Configuration configuration);
    }
}
