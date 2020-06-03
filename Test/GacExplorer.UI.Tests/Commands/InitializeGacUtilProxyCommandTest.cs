using GacExplorer.CommandProxy;
using GacExplorer.Services;
using GacExplorer.Services.OperationResults;
using GacExplorer.UI.Commands;
using GacExplorer.UI.Commands.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GacExplorer.UI.Tests.Commands
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class InitializeGacUtilProxyCommandTest
    {
        private class GacUtilFake : IGacutil
        {
            private string location; 
            public string Location { 
                get  { return location; } 
                set  { location = value; } 
            }

            public string ListAssemblies()
            {
                throw new NotImplementedException();
            }

            public string RegisterAssembly(string path)
            {
                throw new NotImplementedException();
            }

            public string UnregisterAssembly(string name)
            {
                throw new NotImplementedException();
            }
        }

        private class ShowGacFileDialogCommandFake : ICommand
        {
            public bool IsInvoked { get; private set; } = false; 
            public void Execute()
            {
                IsInvoked = true; 
            }
        }

        [TestMethod]
        public void Execute_LocationServiceReadFailed_DoNotSetLocation()
        {
            Mock<ICommand> showGacFileDialogCommandMock = new Mock<ICommand>();
            Mock<IGacutilLocationService> gacutilLocationServiceMock = new Mock<IGacutilLocationService>();
            gacutilLocationServiceMock.Setup(m => m.Read()).Returns(new GacutilLocationReadResult(OperationResult.Failed));
            var gacUtilMock = new GacUtilFake(); 
            var command = new InitializeGacUtilProxyCommand(
                showGacFileDialogCommandMock.Object, gacutilLocationServiceMock.Object, gacUtilMock);
            command.Execute();

            var isLocationSet = !String.IsNullOrEmpty(gacUtilMock.Location);
            Assert.IsFalse(isLocationSet); 
        }

        [TestMethod]
        public void Execute_FileExist_SetLocation()
        {
            var expectedLocation = @"c:\Folder\gacutil.exe"; 
            Mock<ICommand> showGacFileDialogCommandMock = new Mock<ICommand>();
            Mock<IGacutilLocationService> gacutilLocationServiceMock = new Mock<IGacutilLocationService>();
            gacutilLocationServiceMock.Setup(m => m.FileExists(expectedLocation)).Returns(true); 

            var results = new GacutilLocationReadResult(OperationResult.Success);
            results.Location = expectedLocation; 
            gacutilLocationServiceMock.Setup(m => m.Read()).Returns(results);

            var gacUtilMock = new GacUtilFake();

            var command = new InitializeGacUtilProxyCommand(
                showGacFileDialogCommandMock.Object, gacutilLocationServiceMock.Object, gacUtilMock);
            command.Execute();

            var actualLocation = gacUtilMock.Location;
            Assert.AreEqual(expectedLocation, actualLocation); 
        }

        [TestMethod]
        public void Execute_FileODesNotExist_InvokeSetFileDialogCommand()
        {
            var showGacFileDialogCommandMock = new ShowGacFileDialogCommandFake(); 
            Mock<IGacutilLocationService> gacutilLocationServiceMock = new Mock<IGacutilLocationService>();
            gacutilLocationServiceMock.Setup(m => m.FileExists(It.IsAny<string>())).Returns(false);

            var results = new GacutilLocationReadResult(OperationResult.Success);
            gacutilLocationServiceMock.Setup(m => m.Read()).Returns(results);

            var gacUtilMock = new GacUtilFake();

            var command = new InitializeGacUtilProxyCommand(
                showGacFileDialogCommandMock, gacutilLocationServiceMock.Object, gacUtilMock);
            command.Execute();

            Assert.IsTrue(showGacFileDialogCommandMock.IsInvoked);
        }
    }
}
