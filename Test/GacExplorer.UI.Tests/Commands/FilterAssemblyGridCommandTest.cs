using GacExplorer.Services.DTO;
using GacExplorer.UI.Commands;
using GacExplorer.UI.Properties;
using GacExplorer.UI.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private class DataGridViewMock : IDataGridView
        {
            BindingSource bindingSource = new BindingSource();
            public bool IsRefreshed { get; private set; } = false;

            public object DataSource 
            {
                get { return (object)bindingSource; }
                set { this.bindingSource = value as BindingSource; }  
            }

            public void Refresh()
            {
                IsRefreshed =  true; 
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
            dataGridViewStub.Setup(s => s.DataSource).Returns(new BindingSource() { DataSource = new List<object>() });
            var command = new FilterAssemblyGridCommand(dataGridViewStub.Object, textBox, messageBoxMock);
            command.Execute();

            Assert.AreEqual(expectedMessage, messageBoxMock.ShownMessage);
        }

        [TestMethod]
        public void Execute_FiltedTextIsGreaterThan2_SetFilteredDataSource()
        {

            int expectedFilteredDataCount = 1;
            var gridViewMock = new DataGridViewMock();

            var command = Setup(gridViewMock, "ABC"); 
            command.Execute();

            var actualFilteredDataCount = ((BindingList<AssemblyLineDto>)((BindingSource)gridViewMock.DataSource).DataSource).Count;

            Assert.AreEqual(expectedFilteredDataCount, actualFilteredDataCount); 
        }

        [TestMethod]
        public void Execute_FiltedTextIsLessThan2_SetNotFiltereDataSource()
        {
            int expectedFilteredDataCount = 2;
            var gridViewMock = new DataGridViewMock();

            var command = Setup(gridViewMock, "AB");
            command.Execute();

            var actualFilteredDataCount = ((BindingList<AssemblyLineDto>)((BindingSource)gridViewMock.DataSource).DataSource).Count;

            Assert.AreEqual(expectedFilteredDataCount, actualFilteredDataCount);
        }

        [TestMethod]
        public void Execute_SetFiltedText_IsRefreshed()
        {
            var gridViewMock = new DataGridViewMock();

            var command = Setup(gridViewMock, "POI");
            command.Execute();

            Assert.IsTrue(gridViewMock.IsRefreshed);
        }

        private FilterAssemblyGridCommand Setup(DataGridViewMock gridViewMock, string filterText)
        {
            var textBox = new TextBox();
            textBox.Text = filterText;
            var messageBoxMock = new MessageBoxMock();

            Program.AssemblyLineList = new List<AssemblyLineDto>(){
                    new AssemblyLineDto() { Name = "ABCDEFG" },
                    new AssemblyLineDto() { Name = "QWEZXC" } };

            ((BindingSource)gridViewMock.DataSource).DataSource = new BindingList<AssemblyLineDto>(Program.AssemblyLineList); ;

            return new FilterAssemblyGridCommand(gridViewMock, textBox, messageBoxMock);
        }
    }
}
