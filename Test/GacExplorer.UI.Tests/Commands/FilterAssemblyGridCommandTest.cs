using GacExplorer.UI.Commands;
using GacExplorer.UI.Properties;
using GacExplorer.UI.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace GacExplorer.UI.Tests.Commands
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class FilterAssemblyGridCommandTest : CommandTestBase
    {
        private class MessageBoxMock : IMessageBox
        {
            public string ShownMessage { get; private set; }
            public DialogResult Show(string text)
            {
                this.ShownMessage = text;
                return new DialogResult(); 
            }

            public DialogResult Show(string text, string caption, MessageBoxButtons buttons)
            {
                throw new NotImplementedException();
            }
        }
        [TestMethod]
        public void Execute_DataSourceIsNotBindingSource_ShowError()
        {
            var expectedMessage = Resources.InvalidDataGridDataSourceType; 
            var textBox = new TextBox();
            var messageBoxMock = new MessageBoxMock(); 
            Mock<IDataGridView> dataGridViewStub = new Mock<IDataGridView>();
            dataGridViewStub.Setup(s => s.DataSource).Returns(new object()); 

            var command = new FilterAssemblyGridCommand(dataGridViewStub.Object, textBox, messageBoxMock);
            command.Execute();

            Assert.AreEqual(expectedMessage, messageBoxMock.ShownMessage); 
        }

        [TestMethod]
        public void Execute_BindingSourceIsNotBindingList_ShowError()
        {
            var expectedMessage = Resources.InvalidBindingListContent; 
            var textBox = new TextBox();
            var messageBoxMock = new MessageBoxMock();
            Mock<IDataGridView> dataGridViewStub = new Mock<IDataGridView>();
            //TODO: Setup DataSource to return something different that BindingList<AssemblyLineDto> 
            var command = new FilterAssemblyGridCommand(dataGridViewStub.Object, textBox, messageBoxMock);
            command.Execute();

            Assert.AreEqual(expectedMessage, messageBoxMock.ShownMessage);
        }

        [TestMethod]
        public void Execute_FiltedTextIsGreaterThan2_SetFilteredDataSource()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Execute_FiltedTextIsLessThan2_SetNotFiltereDataSource()
        {
            throw new NotImplementedException();
        }
    }
}
