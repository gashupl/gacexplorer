using GacExplorer.Services.Wrappers;
using System;
using System.Configuration;

namespace GacExplorer.Services
{
    public class ApplicationConfigurationService : IApplicationConfigurationService
    {

        public ConfigurationWrapper GetConfiguration()
        {
            var assemblyLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
            var appConfig = ConfigurationManager.OpenExeConfiguration(assemblyLocation);
            return new ConfigurationWrapper(appConfig); 
        }

        public ServiceOperationResult RefreshConfigurationSettings()
        {
            try
            {
                ConfigurationManager.RefreshSection("appSettings");
                return new ServiceOperationResult(OperationResult.Success); 
            }
            catch(Exception ex)
            {
                return new ServiceOperationResult(OperationResult.Failed, "Cannot refresh application configuration", ex); 
            }
      
        }

        public ServiceOperationResult SaveConfiguration(ConfigurationWrapper configuration)
        {
            try
            {
                configuration.Save(ConfigurationSaveMode.Modified);
                return new ServiceOperationResult(OperationResult.Success);
            }
            catch (Exception ex)
            {
                return new ServiceOperationResult(OperationResult.Failed, "Cannot save application configuration", ex);
            }
           
        }

        public KeyValueConfigurationCollection GetSettings(ConfigurationWrapper configuration)
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
