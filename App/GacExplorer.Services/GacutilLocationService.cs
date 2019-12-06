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
            this.log.Trace($"{nameof(GacutilLocationService)} initialized");
            this.appConfigurationService = appConfigurationService;
            this.file = file; 
        }

        public GacutilLocationReadResult Read()
        {
            this.log.Trace($"{nameof(GacutilLocationReadResult)} method executed");
            try
            {
                IConfiguration appConfig = this.appConfigurationService.GetConfiguration();
                var appSettings = this.appConfigurationService.GetSettings(appConfig);
                var result = new GacutilLocationReadResult(OperationResult.Success);
                result.Location = appSettings[locationKey] != null ? appSettings[locationKey].Value : null;
                this.log.Info($"Location found: { result.Location}");
                return result;
            }
            catch(Exception ex)
            {
                log.Error(ex, $"{nameof(Read)} failed");
                return new GacutilLocationReadResult(OperationResult.Failed, "GacutilLocationService.Read operation failed", ex);
            }
        }


        public ServiceOperationResult Save(string fileLocation)
        {
            this.log.Trace($"{nameof(Save)} method executed with parameter fileLocation: {fileLocation}");
            try
            {
                IConfiguration appConfig = this.appConfigurationService.GetConfiguration();
                var appSettings = this.appConfigurationService.GetSettings(appConfig); 
                if (appSettings[locationKey] == null)
                {
                    appSettings.Add(locationKey, fileLocation);
                    this.log.Info($"New appSettings key added: {fileLocation}");
                }
                else
                {
                    appSettings[locationKey].Value = fileLocation;
                    this.log.Info($"AppSettings key updated. New value: {fileLocation}");
                }

                var result = this.appConfigurationService.SaveConfiguration(appConfig);
                if(result.Result == OperationResult.Failed)
                {
                    this.log.Warning($"Saving configuration failed");
                    return result; 
                }
                else
                {
                    return this.appConfigurationService.RefreshConfigurationSettings();
                }
            }
            catch(ConfigurationErrorsException ex)
            {
                log.Error(ex, $"{nameof(Save)} failed");
                return new ServiceOperationResult(
                    OperationResult.Failed, "GacutilLocationService.Save operation failed", ex);
            }
            catch(Exception ex)
            {
                log.Error(ex, $"{nameof(Save)} failed");
                return new ServiceOperationResult(
                    OperationResult.Failed, "GacutilLocationService.Save operation failed", ex);
            }
        }

        public bool FileExists(string location)
        {
            this.log.Trace($"{nameof(FileExists)} method executed with parameter location: {location}");

            var fileExists = this.file.FileExists(location);
            this.log.Info($"File exists value: {fileExists}");

            return fileExists;
        }
    }
}
