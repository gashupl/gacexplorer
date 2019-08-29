using System.Configuration;

namespace GacExplorer.Services
{
    public class ApplicationConfigurationService : IApplicationConfigurationService
    {

        public Configuration GetConfiguration()
        {
            var assemblyLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
            return ConfigurationManager.OpenExeConfiguration(assemblyLocation);
        }

        public void RefreshConfigurationSettings()
        {
            ConfigurationManager.RefreshSection("appSettings");
        }

        public void SaveConfiguration(Configuration configuration)
        {
            configuration.Save(ConfigurationSaveMode.Modified);
        }

        public KeyValueConfigurationCollection GetSettings(Configuration configuration)
        {
            var appSettingsSection = configuration.GetSection("appSettings") as AppSettingsSection;
            if (appSettingsSection != null)
            {
                return appSettingsSection.Settings;
            }
            else
            {
                return null;
            }
        }


    }
}
