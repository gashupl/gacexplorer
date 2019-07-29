using System.Configuration;

namespace GacExplorer.Services
{
    public interface IApplicationService
    {
        Configuration GetApplicationConfiguration(); 
    }
}
