using System;
using System.Configuration;

namespace GacExplorer.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private const string locationKey = "GacUtilLocation";

        private IApplicationService applicationService;
        private IConfigurationFileService configurationFileService; 

        public ConfigurationService(IApplicationService applicationService, IConfigurationFileService configurationFileService)
        {
            this.applicationService = applicationService;
            this.configurationFileService = configurationFileService; 
        }

        public ServiceOperationResult ReadGacutilLocation()
        {
            throw new NotImplementedException();
        }

        public ServiceOperationResult SaveGacutilLocation(string fileLocation)
        {
            try
            {
                Configuration appConfig = this.applicationService.GetApplicationConfiguration();
                var appSettings = this.configurationFileService.GetSettings(appConfig); 
                if (appSettings[locationKey] == null)
                {
                    appSettings.Add(locationKey, fileLocation);
                }

                else
                {
                    appSettings[locationKey].Value = fileLocation;
                }

                this.configurationFileService.SaveConfiguration(appConfig); 
                this.configurationFileService.RefreshSettings(); 

                return new ServiceOperationResult(OperationResult.Success); 
            }
            catch(Exception ex)
            {
                return new ServiceOperationResult(
                    OperationResult.Failed, "ConfigurationService.SaveGacutilLocation operation failed", ex);
            }
        }
    }
}
