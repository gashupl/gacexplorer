using System.Configuration;

namespace GacExplorer.Services
{
    public interface IConfigurationFileService
    {
        KeyValueConfigurationCollection GetSettings(Configuration configuration);

        void SaveConfiguration(Configuration configuration);

        void RefreshSettings();


    }
}
