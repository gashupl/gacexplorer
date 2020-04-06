using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GacExplorer.UI.Tests.Commands
{
    [TestClass]
    public class ListAssembliesCommandTest
    {
        [TestMethod]
        public void Execute_EmptyLocationString_InvokeInitializeGacUtilProxyCommand()
        {
            throw new NotImplementedException(); 
        }

        [TestMethod]
        public void Execute_GacServiceNotExists_InitializeGacService()
        {
            //TODO: Possible refactoring - use factory to initialize Gac Service
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Execute_AssemblyLineListIsNull_DoNotSetDataSourceAndAssemblyCount()
        {
            //TODO: Possible refactoring - separate commands for setting data source and assembly count
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Execute_AssemblyLineListIsNotNull_SetDataSourceAndAssemblyCount()
        {
            throw new NotImplementedException();
        }
    }
}
