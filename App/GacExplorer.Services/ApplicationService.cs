using System.Configuration;

namespace GacExplorer.Services
{
    public class ApplicationService : IApplicationService
    {
        public Configuration GetApplicationConfiguration()
        {
            var assemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location; 
            return ConfigurationManager.OpenExeConfiguration(assemblyLocation);
        }
    }
}
