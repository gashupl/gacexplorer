using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GacExplorer.UI.Tests.Commands
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class RemoveAssemblyCommandTest : CommandTestBase
    {

        [TestMethod]
        public void Execute_EmptyLocation_ShowMessageBox()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Execute_SelectedAssembliesNotEqualOne_ShowErrorMessage()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Execute_OperatonSuccess_ShowSucceedMessage()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Execute_OperatonFailed_ShowErrorMessage()
        {
            throw new NotImplementedException();
        }
    }
}
