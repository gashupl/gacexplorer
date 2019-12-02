using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
