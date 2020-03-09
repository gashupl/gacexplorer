using System.Diagnostics.CodeAnalysis;
using GacExplorer.UI.Commands;
using GacExplorer.UI.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GacExplorer.UI.Tests.Commands
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ApplicationExitCommandTest : CommandTestBase
    {
        private class ApplicationMock : IApplication
        {
            public bool ExitExecuted { get; private set; } = false; 

            public void Exit()
            {
                ExitExecuted = true; 
            }
        }

        [TestMethod]
        public void Execute()
        {
            var application = new ApplicationMock(); 
            var command = new ApplicationExitCommand(application);
            command.Execute();

            Assert.IsTrue(application.ExitExecuted); 
        }
    }
}
