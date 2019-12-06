using GacExplorer.Logging;

namespace GacExplorer.Services
{
    public abstract class ServiceBase
    {
        protected ILog log;

        protected ServiceBase(ILog log)
        {
            this.log = log;
        }
    }
}
