using System.Windows.Forms;
using GacExplorer.Logging;
using GacExplorer.UI.Wrappers;
using Moq;

namespace GacExplorer.UI.Tests.Commands
{
    public abstract class CommandTestBase
    {
        private  Mock<IMessageBox> messageBoxMock;
        private Mock<ILog> logMock; 

        protected IMessageBox MessageBoxMockObject
        {
            get 
            {
                return messageBoxMock.Object; 
            }
        }
        protected ILog LogMockObject
        {
            get { return logMock.Object;  }
        }

        public CommandTestBase()
        {
            messageBoxMock = new Mock<IMessageBox>();
            messageBoxMock.Setup(m => m.Show(It.IsAny<string>()));
            messageBoxMock.Setup(m => m.Show(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<MessageBoxButtons>()));

            logMock = new Mock<ILog>();
            logMock.Setup(m => m.Trace(It.IsAny<string>())); 
        }
    }
}
