using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GacExplorer.CommandProxy;
using GacExplorer.Services.OperationResults;

namespace GacExplorer.Services.Tests
{
    [TestClass]
    public class GlobalAssemblyCacheServiceTest
    {
        [TestMethod]
        public void GetAssemblyLines_ValidOutput_ReturnSucessGetAssemblyLinesOperationResult()
        {
            //var expectedLines = 50;
            //var location = ""; 
            //var gacProxy = new Gacutil(location); 
            //var service = new GlobalAssemblyCacheService(gacProxy);
            //var response = service.GetAssemblyLines();
            //Assert.AreEqual(OperationResult.Success, response.Result);
            //Assert.AreEqual(expectedLines, response.AssemblyLines.Count); 
            throw new NotImplementedException(); 
        }

        [TestMethod]
        public void GetAssemblyLines_InvalidOutput_ReturnFailedGetAssemblyLinesOperationResult()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void GetAssemblyLines_EmptyOutput_ReturnFailedGetAssemblyLinesOperationResult()
        {
            throw new NotImplementedException();
        }
    }
}
