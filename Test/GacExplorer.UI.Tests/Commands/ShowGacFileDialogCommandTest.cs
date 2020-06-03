using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using GacExplorer.CommandProxy;
using GacExplorer.Services;
using GacExplorer.Services.OperationResults;
using GacExplorer.UI.Commands;
using GacExplorer.UI.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GacExplorer.UI.Tests.Commands
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ShowGacFileDialogCommandTest : CommandTestBase
    {
        private class GacUtilLocationServiceMock : IGacutilLocationService
        {
            public bool Saved { get; private set; }

            public ServiceOperationResult Save(string fileLocation)
            {
                this.Saved = true;
                return new ServiceOperationResult(OperationResult.Success); 
            }

            public GacutilLocationReadResult Read()
            {
                throw new NotImplementedException();
            }

            public bool FileExists(string location)
            {
                throw new NotImplementedException();
            }
        }
        [TestMethod]
        public void Execute_DialogOk_LocationSaved()
        {
            Mock<IOpenFileDialog> okFileDialog = new Mock<IOpenFileDialog>();
            okFileDialog.Setup(m => m.Dispose());
            okFileDialog.Setup(m => m.ShowDialog()).Returns(DialogResult.OK);

            var gacUtilLocationServiceMock = new GacUtilLocationServiceMock();

            Mock<IGacutil> gacUtilMock = new Mock<IGacutil>();

            var command = new ShowGacFileDialogCommand(okFileDialog.Object, gacUtilLocationServiceMock, gacUtilMock.Object, this.MessageBoxMockObject);
            command.Execute();

            Assert.IsTrue(gacUtilLocationServiceMock.Saved); 
        }

        [TestMethod]
        public void Execute_DialogOk_LocationNotSaved()
        {
            Mock<IOpenFileDialog> okFileDialog = new Mock<IOpenFileDialog>();
            okFileDialog.Setup(m => m.Dispose());
            okFileDialog.Setup(m => m.ShowDialog()).Returns(DialogResult.Cancel);

            var gacUtilLocationServiceMock = new GacUtilLocationServiceMock();

            Mock<IGacutil> gacUtilMock = new Mock<IGacutil>();

            var command = new ShowGacFileDialogCommand(okFileDialog.Object, gacUtilLocationServiceMock, gacUtilMock.Object, this.MessageBoxMockObject);
            command.Execute();

            Assert.IsFalse(gacUtilLocationServiceMock.Saved);
        }

        [TestMethod]
        public void Execute_SaveFailed_LocationNotSaved()
        {
            Mock<IOpenFileDialog> okFileDialog = new Mock<IOpenFileDialog>();
            okFileDialog.Setup(m => m.Dispose());
            okFileDialog.Setup(m => m.ShowDialog()).Returns(DialogResult.OK);

            var gacUtilLocationServiceMock = new Mock<IGacutilLocationService>();
            gacUtilLocationServiceMock.Setup(m => m.Save(It.IsAny<string>())).Returns(new ServiceOperationResult(OperationResult.Failed)); 

            Mock <IGacutil> gacUtilMock = new Mock<IGacutil>();

            var command = new ShowGacFileDialogCommand(okFileDialog.Object, gacUtilLocationServiceMock.Object, gacUtilMock.Object, this.MessageBoxMockObject);
            command.Execute();

            Assert.IsNull(gacUtilMock.Object.Location); 
        }
    }
}
