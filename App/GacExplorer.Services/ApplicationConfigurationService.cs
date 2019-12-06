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
            this.log.Trace($"{nameof(ApplicationConfigurationService)} initialized"); 
        }

        public IConfiguration GetConfiguration()
        {
            var assemblyLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
            var appConfig = ConfigurationManager.OpenExeConfiguration(assemblyLocation);
            return new ConfigurationWrapper(appConfig); 
        }

        public ServiceOperationResult RefreshConfigurationSettings()
        {
            this.log.Trace($"{nameof(ServiceOperationResult)} method executed");
            try
            {
                ConfigurationManager.RefreshSection("appSettings");
                return new ServiceOperationResult(OperationResult.Success); 
            }
            catch(Exception ex)
            {
                log.Error(ex, $"{nameof(RefreshConfigurationSettings)} failed");
                return new ServiceOperationResult(OperationResult.Failed, "Cannot refresh application configuration", ex); 
            }
      
        }

        public ServiceOperationResult SaveConfiguration(IConfiguration configuration)
        {
            this.log.Trace($"{nameof(SaveConfiguration)} method executed");
            try
            {
                configuration.Save(ConfigurationSaveMode.Modified);
                return new ServiceOperationResult(OperationResult.Success);
            }
            catch (Exception ex)
            {
                log.Error(ex, $"{nameof(SaveConfiguration)} failed");
                return new ServiceOperationResult(OperationResult.Failed, "Cannot save application configuration", ex);
            }
           
        }

        public KeyValueConfigurationCollection GetSettings(IConfiguration configuration)
        {
            this.log.Trace($"{nameof(GetSettings)} method executed");
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
