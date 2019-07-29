using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GacExplorer.Services
{
    class ConfigurationFileService : IConfigurationFileService
    {
        public KeyValueConfigurationCollection GetSettings(Configuration configuration)
        {
            var appSettingsSection = configuration.GetSection("appSettings") as AppSettingsSection;
            if(appSettingsSection != null)
            {
                return appSettingsSection.Settings; 
            }
            else
            {
                return null; 
            }
        }

        public void RefreshSettings()
        {
            ConfigurationManager.RefreshSection("appSettings");
        }

        public void SaveConfiguration(Configuration configuration)
        {
            configuration.Save(ConfigurationSaveMode.Modified);
        }

    }
}
