using GacExplorer.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace GacExplorer.Services.Tests
{
    public abstract class ServiceTestBase
    {
        private ILog log;

        protected ILog Log
        {
            get { return log ?? (log = GetLockMock()); }
        }

        private ILog GetLockMock()
        {
            var logMock = new Moq.Mock<ILog>();
            logMock.Setup(l => l.Trace(It.IsAny<string>()));
            logMock.Setup(l => l.Debug(It.IsAny<string>()));
            logMock.Setup(l => l.Info(It.IsAny<string>()));
            logMock.Setup(l => l.Warning(It.IsAny<string>()));
            logMock.Setup(l => l.Error(It.IsAny<string>()));
            logMock.Setup(l => l.Error(It.IsAny<Exception>(), It.IsAny<string>()));
            logMock.Setup(l => l.Fatal(It.IsAny<string>()));
            return logMock.Object; 
        }
    }
}
