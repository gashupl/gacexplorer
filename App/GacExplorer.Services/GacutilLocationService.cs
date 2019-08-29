using GacExplorer.Services.Wrappers;
using System;
using System.Configuration;

namespace GacExplorer.Services
{
    public class GacutilLocationService : IGacutilLocationService
    {
        private const string locationKey = "GacUtilLocation";

        private IApplicationConfigurationService appConfigurationService;

        public GacutilLocationService(IApplicationConfigurationService appConfigurationService)
        {
            this.appConfigurationService = appConfigurationService;
        }

        public ServiceOperationResult Read()
        {
            throw new NotImplementedException();
        }

        public ServiceOperationResult Save(string fileLocation)
        {
            try
            {
                IConfiguration appConfig = this.appConfigurationService.GetConfiguration();
                var appSettings = this.appConfigurationService.GetSettings(appConfig); 
                if (appSettings[locationKey] == null)
                {
                    appSettings.Add(locationKey, fileLocation);
                }

                else
                {
                    appSettings[locationKey].Value = fileLocation;
                }


                var result = this.appConfigurationService.SaveConfiguration(appConfig);
                if(result.Result == OperationResult.Failed)
                {
                    return result; 
                }

                result = this.appConfigurationService.RefreshConfigurationSettings();
                if (result.Result == OperationResult.Failed)
                {
                    return result;
                }

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
