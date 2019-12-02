using GacExplorer.Services.OperationResults;
using GacExplorer.Services.Wrappers;
using System;
using System.Configuration;
using GacExplorer.Logging;

namespace GacExplorer.Services
{
    public class GacutilLocationService : ServiceBase, IGacutilLocationService
    {
        private const string locationKey  =  "GacUtilLocation";

        public static string LocationKey
        {
            get
            {
                return locationKey; 
            }
        }

        private IApplicationConfigurationService appConfigurationService;
        private IFile file; 

        public GacutilLocationService(IApplicationConfigurationService appConfigurationService, IFile file, ILog log) : base(log)
        {
            this.appConfigurationService = appConfigurationService;
            this.file = file; 
        }

        public GacutilLocationReadResult Read()
        {
            try
            {
                IConfiguration appConfig = this.appConfigurationService.GetConfiguration();
                var appSettings = this.appConfigurationService.GetSettings(appConfig);
                var result = new GacutilLocationReadResult(OperationResult.Success);
                result.Location = appSettings[locationKey] != null ? appSettings[locationKey].Value : null; 
                return result;
            }
            catch(Exception ex)
            {
                return new GacutilLocationReadResult(OperationResult.Failed, "GacutilLocationService.Read operation failed", ex);
            }
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
                else
                {
                    return this.appConfigurationService.RefreshConfigurationSettings();
                }
            }
            catch(ConfigurationErrorsException ex)
            {
                return new ServiceOperationResult(
                    OperationResult.Failed, "GacutilLocationService.Save operation failed", ex);
            }
            catch(Exception ex)
            {
                return new ServiceOperationResult(
                    OperationResult.Failed, "GacutilLocationService.Save operation failed", ex);
            }
        }

        public bool FileExists(string location)
        {
            return this.file.FileExists(location); 
        }
    }
}
