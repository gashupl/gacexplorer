using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GacExplorer.CommandProxy;
using GacExplorer.Services;
using GacExplorer.Services.DTO;
using GacExplorer.Services.OperationResults;
using GacExplorer.UI.Commands;
using GacExplorer.UI.Commands.Base;
using GacExplorer.UI.Commands.Settings;
using Moq;

namespace GacExplorer.UI.Tests.Commands
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ListAssembliesCommandTest : CommandTestBase
    {
        private class CommandFake : ICommand
        {
            public bool Invoked { get; private set; }
            public void Execute()
            {
                Invoked = true;
            }
        }

        [TestMethod]
        public void Execute_EmptyLocationString_InvokeInitializeGacUtilProxyCommand()
        {
            var gacUtilProxyMock = new Mock<IGacutil>();
            gacUtilProxyMock.Setup(m => m.Location).Returns(String.Empty);

            var initializeGacUtilProxyCommandMock = new CommandFake(); 
            var settings = new ListAssembliesCommandSettings()
            {
                GacutilLocationService = null,
                ParserService = null,
                GacService = null,
                GacUtilProxy = gacUtilProxyMock.Object,
                AssemblyLineList = null, 
                Log = this.LogMockObject,
                ShowGacFileDialogCommand = new CommandFake(),
                InitializeGacUtilProxyCommand = initializeGacUtilProxyCommandMock,
                GridViewAssemblies = null, 
                LblAssemblyListCount = null
            }; 

            var command = new ListAssembliesCommand(settings);
            command.Execute();

            Assert.IsTrue(initializeGacUtilProxyCommandMock.Invoked); 
        }

        [TestMethod]
        public void Execute_AssemblyLineListIsNull_DoNotSetDataSourceAndAssemblyCount()
        {
            var gacUtilProxyMock = new Mock<IGacutil>();
            gacUtilProxyMock.Setup(m => m.Location).Returns(@"c:\Location\gacutil.exe");

            var gacServiceMock = new Mock<IGlobalAssemblyCacheService>();
            gacServiceMock.Setup(m => m.GetAssemblyLines()).Returns(new GetAssemblyLinesOperationResult(OperationResult.Success)
            {
                AssemblyLines = new List<AssemblyLineDto>() { new AssemblyLineDto() }
            }); 

            var initializeGacUtilProxyCommandMock = new CommandFake();
            var settings = new ListAssembliesCommandSettings()
            {

                GacutilLocationService = null,
                ParserService = null,
                GacService = gacServiceMock.Object,
                GacUtilProxy = gacUtilProxyMock.Object,
                AssemblyLineList = null,
                Log = this.LogMockObject,
                ShowGacFileDialogCommand = new CommandFake(),
                InitializeGacUtilProxyCommand = initializeGacUtilProxyCommandMock,
                GridViewAssemblies = new DataGridView(),
                LblAssemblyListCount = new Label() 
            };

            var command = new ListAssembliesCommand(settings);
            command.Execute();

            Assert.IsNotNull(settings.GridViewAssemblies.DataSource);
            Assert.AreEqual("1", settings.LblAssemblyListCount.Text); 
        }
    }
}
