using System.Windows.Forms;
using GacExplorer.UI.Wrappers;
using Moq;

namespace GacExplorer.UI.Tests.Commands
{
    public abstract class CommandTestBase
    {
        private  Mock<IMessageBox> messageBoxMock;

        protected IMessageBox MessageBoxMockObject
        {
            get 
            {
                return messageBoxMock.Object; 
            }
        }

        public CommandTestBase()
        {
            messageBoxMock = new Mock<IMessageBox>();
            messageBoxMock.Setup(m => m.Show(It.IsAny<string>()));
            messageBoxMock.Setup(m => m.Show(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<MessageBoxButtons>())); 
        }
    }
}
