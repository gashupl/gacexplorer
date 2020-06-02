using System;
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
    public class RegisterAssemblyCommandTest : CommandTestBase
    {
        private class MessageBoxStub : IMessageBox
        {
            public bool Shown { get; private set; } = false;
            public bool ShownSuccess { get; private set; } = false;
            public bool ShownFailure { get; private set; } = false;
            public bool ShownWithButtons { get; private set; } = false;

            public DialogResult Show(string text)
            {
                Shown = true;
                if (text == Resources.AssemblySuccessfullyRegisteredInGac)
                {
                    ShownSuccess = true;
                }
                else if (text == $"{Resources.ErrorWhenRegisteringAssemblyInGac}: ")
                {
                    ShownFailure = true; 
                }
                return new DialogResult();
            }

            public DialogResult Show(string text, string caption, MessageBoxButtons buttons)
            {
                ShownWithButtons = true;
                return new DialogResult();
            }
        }


        [TestMethod]
        public void Execute_EmptyLocation_ShowMessageBox()
        {
            var messageBox = new MessageBoxStub();

            var gacUtil = new Gacutil();

            var settings = new RegisterAssemblyCommandSettings()
            {
                GacUtilProxy = gacUtil, 

            };
            var command = new RegisterAssemblyCommand(settings, messageBox);
            command.Execute(); 
            Assert.IsTrue(messageBox.Shown);
        }

        [TestMethod]
        public void Execute_OperatonSuccess_ShowSucceedMessage()
        {
            var messageBox = new MessageBoxStub();

            var gacUtil = new Gacutil();
            gacUtil.Location = @"c:\gacutil.exe";

            var assemblyFileDialogStub = new Mock<IOpenFileDialog>();
            assemblyFileDialogStub.Setup(m => m.ShowDialog()).Returns(DialogResult.OK);

            var gacServiceStub = new Mock<IGlobalAssemblyCacheService>();
            gacServiceStub.Setup(m => m.RegisterAssembly(It.IsAny<string>()))
                .Returns(new ServiceOperationResult(OperationResult.Success));

            var listAssembliesCommand = new Mock<ICommand>();
            listAssembliesCommand.Setup(m => m.Execute());

            var settings = new RegisterAssemblyCommandSettings()
            {
                GacUtilProxy = gacUtil,
                AddAssemblyFileDialog = assemblyFileDialogStub.Object,
                GacService = gacServiceStub.Object,
                ListAssembliesCommand = listAssembliesCommand.Object
            };
            var command = new RegisterAssemblyCommand(settings, messageBox);
            command.Execute();
            Assert.IsTrue(messageBox.ShownSuccess);
        }

        [TestMethod]
        public void Execute_OperatonFailed_ShowErrorMessage()
        {
            var messageBox = new MessageBoxStub();

            var gacUtil = new Gacutil();
            gacUtil.Location = @"c:\gacutil.exe";

            var assemblyFileDialogStub = new Mock<IOpenFileDialog>();
            assemblyFileDialogStub.Setup(m => m.ShowDialog()).Returns(DialogResult.OK);

            var gacServiceStub = new Mock<IGlobalAssemblyCacheService>();
            gacServiceStub.Setup(m => m.RegisterAssembly(It.IsAny<string>()))
                .Returns(new ServiceOperationResult(OperationResult.Failed));


            var settings = new RegisterAssemblyCommandSettings()
            {
                GacUtilProxy = gacUtil,
                AddAssemblyFileDialog = assemblyFileDialogStub.Object,
                GacService = gacServiceStub.Object
            };
            var command = new RegisterAssemblyCommand(settings, messageBox);
            command.Execute();
            Assert.IsTrue(messageBox.ShownFailure);
        }
    }
}
