using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using GacExplorer.CommandProxy;
using GacExplorer.Services;
using GacExplorer.Services.OperationResults;
using GacExplorer.UI.Commands;
using GacExplorer.UI.Commands.Base;
using GacExplorer.UI.Commands.Settings;
using GacExplorer.UI.Properties;
using GacExplorer.UI.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GacExplorer.UI.Tests.Commands
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class RemoveAssemblyCommandTest : CommandTestBase
    {
        private class MessageBoxStub : IMessageBox
        {
            public bool Shown { get; private set; } = false;
            public bool NoSelectedRowsMessageShown { get; private set; } = false;
            public bool ShownSuccess { get; private set; } = false;
            public bool ShownFailure { get; private set; } = false;

            public DialogResult Show(string text)
            {
                Shown = true;
                if(text == Resources.SelectSingleAssemblyToBeUninstalledFromGac)
                {
                    NoSelectedRowsMessageShown = true; 
                }
                if (text == Resources.AssemblySuccessfullyUnregisteredFromGac)
                {
                    ShownSuccess = true;
                }
                else if (text == $"{Resources.ErrorWhenUnregisteringAssemblyFromGac}: ")
                {
                    ShownFailure = true;
                }
                return DialogResult.Yes;
            }

            public DialogResult Show(string text, string caption, MessageBoxButtons buttons)
            {
                return DialogResult.Yes;
            }
        }


        [TestMethod]
        public void Execute_EmptyLocation_ShowMessageBox()
        {
            var messageBox = new MessageBoxStub();

            var gacUtil = new Gacutil();

            var settings = new RemoveAssemblyCommandSettings()
            {
                GacUtilProxy = gacUtil,

            };
            var command = new RemoveAssemblyCommand(settings, messageBox);
            command.Execute();
            Assert.IsTrue(messageBox.Shown);
        }

        [TestMethod]
        public void Execute_SelectedAssembliesNotEqualOne_ShowErrorMessage()
        {
            var gridViewAssemblies = GetGridView(false); 

            var gacUtil = new Gacutil();
            gacUtil.Location = @"c:\gacutil.exe";

            var messageBox = new MessageBoxStub();

            var settings = new RemoveAssemblyCommandSettings()
            {
                GacUtilProxy = gacUtil,
                GridViewAssemblies = gridViewAssemblies
            };
            var command = new RemoveAssemblyCommand(settings, messageBox);
            command.Execute();

            Assert.IsTrue(messageBox.NoSelectedRowsMessageShown); 
        }

        [TestMethod]
        public void Execute_OperatonSuccess_ShowSucceedMessage()
        {
            var gridViewAssemblies = GetGridView(true);

            var gacUtil = new Gacutil();
            gacUtil.Location = @"c:\gacutil.exe";

            var messageBox = new MessageBoxStub();

            var assemblyFileDialogStub = new Mock<IOpenFileDialog>();
            assemblyFileDialogStub.Setup(m => m.ShowDialog()).Returns(DialogResult.OK);

            var gacServiceStub = new Mock<IGlobalAssemblyCacheService>();
            gacServiceStub.Setup(m => m.UnregisterAssembly(It.IsAny<string>()))
                .Returns(new ServiceOperationResult(OperationResult.Success));

            var listAssembliesCommand = new Mock<ICommand>();
            listAssembliesCommand.Setup(m => m.Execute());

            var settings = new RemoveAssemblyCommandSettings()
            {
                GacUtilProxy = gacUtil,
                GridViewAssemblies = gridViewAssemblies, 
                GacService = gacServiceStub.Object, 
                ListAssembliesCommand = listAssembliesCommand.Object
            };

            var command = new RemoveAssemblyCommand(settings, messageBox);
            command.Execute();

            Assert.IsTrue(messageBox.ShownSuccess);
        }

        [TestMethod]
        public void Execute_OperatonFailed_ShowErrorMessage()
        {
            var gridViewAssemblies = GetGridView(true);

            var gacUtil = new Gacutil();
            gacUtil.Location = @"c:\gacutil.exe";

            var messageBox = new MessageBoxStub();

            var assemblyFileDialogStub = new Mock<IOpenFileDialog>();
            assemblyFileDialogStub.Setup(m => m.ShowDialog()).Returns(DialogResult.OK);

            var gacServiceStub = new Mock<IGlobalAssemblyCacheService>();
            gacServiceStub.Setup(m => m.UnregisterAssembly(It.IsAny<string>()))
                .Returns(new ServiceOperationResult(OperationResult.Failed));

            var settings = new RemoveAssemblyCommandSettings()
            {
                GacUtilProxy = gacUtil,
                GridViewAssemblies = gridViewAssemblies,
                GacService = gacServiceStub.Object,
            };

            var command = new RemoveAssemblyCommand(settings, messageBox);
            command.Execute();

            Assert.IsTrue(messageBox.ShownFailure);
        }

        private DataGridView GetGridView(bool isRowSelected)
        {
            var gridViewAssemblies = new DataGridView();
            gridViewAssemblies.Columns.Add("Column 1", "Column");
            gridViewAssemblies.Rows.Add(new DataGridViewRow());
            gridViewAssemblies.Rows[0].Selected = isRowSelected;

            return gridViewAssemblies; 
        }
    }
}
