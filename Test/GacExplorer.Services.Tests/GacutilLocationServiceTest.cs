using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GacExplorer.Services.Tests
{
    [TestClass]
    public class GacutilLocationServiceTest
    {
        [TestMethod]
        public void Save_AppServiceKeyDoesNotExist_ReturnServiceOperationResult()
        {
            Mock<IApplicationConfigurationService> appConfigMock = new Mock<IApplicationConfigurationService>();
        
            var gacService = new GacutilLocationService(appConfigMock.Object);
            var result = gacService.Save(String.Empty);

            Assert.AreEqual(result.Result, OperationResult.Success); 
        }

        [TestMethod]
        public void Save_AppServiceKeyExist_ReturnServiceOperationResult()
        {
            Mock<IApplicationConfigurationService> appConfigMock = new Mock<IApplicationConfigurationService>();

            var gacService = new GacutilLocationService(appConfigMock.Object);
            var result = gacService.Save(String.Empty);

            Assert.AreEqual(result.Result, OperationResult.Success);
        }

        [TestMethod]
        public void Save_Failed_ReturnServiceOperationResult()
        {
            Mock<IApplicationConfigurationService> appConfigMock = new Mock<IApplicationConfigurationService>();

            throw new NotImplementedException(); 
            var gacService = new GacutilLocationService(appConfigMock.Object);
            var result = gacService.Save(String.Empty);

            Assert.AreEqual(result.Result, OperationResult.Failed);
        }
    }
}
