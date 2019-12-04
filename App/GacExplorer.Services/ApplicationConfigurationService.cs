using GacExplorer.Services.OperationResults;
using GacExplorer.Services.Wrappers;
using System;
using System.Configuration;
using GacExplorer.Logging;

namespace GacExplorer.Services
{
    public class ApplicationConfigurationService : ServiceBase, IApplicationConfigurationService
    {
        public ApplicationConfigurationService(ILog log) : base(log)
        {
        }

        public IConfiguration GetConfiguration()
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

        public ServiceOperationResult SaveConfiguration(IConfiguration configuration)
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

        public KeyValueConfigurationCollection GetSettings(IConfiguration configuration)
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
