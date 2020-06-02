using System;
using System.Diagnostics.CodeAnalysis;
using GacExplorer.UI.Commands;
using GacExplorer.UI.Commands.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GacExplorer.UI.Tests.Commands
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class RegisterAssemblyCommandTest : CommandTestBase
    {

        [TestMethod]
        public void Execute_EmptyLocation_ShowMessageBox()
        {
            var settings = new RegisterAssemblyCommandSettings();
            var command = new RegisterAssemblyCommand(settings, this.MessageBoxMockObject);
            command.Execute(); 

            Assert.Fail();
        }

        [TestMethod]
        public void Execute_OperatonSuccess_ShowSucceedMessage()
        {
            var settings = new RegisterAssemblyCommandSettings();
            var command = new RegisterAssemblyCommand(settings, this.MessageBoxMockObject);
            command.Execute();

            Assert.Fail();
        }

        [TestMethod]
        public void Execute_OperatonFailed_ShowErrorMessage()
        {
            var settings = new RegisterAssemblyCommandSettings();
            var command = new RegisterAssemblyCommand(settings, this.MessageBoxMockObject);
            command.Execute();

            Assert.Fail();
        }
    }
}
