using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Configuration;
using GacExplorer.Services.Wrappers;

namespace GacExplorer.Services.Tests
{
    [TestClass]
    public class GacutilLocationServiceTest
    {
        [TestMethod]
        public void Save_AppServiceKeyDoesNotExist_ReturnServiceOperationResult()
        {
            Mock<IConfiguration> configurationMock = new Mock<IConfiguration>();

            Mock<IApplicationConfigurationService> appConfigServiceMock = new Mock<IApplicationConfigurationService>();
            appConfigServiceMock.Setup(a => a.GetConfiguration()).Returns(configurationMock.Object);
            appConfigServiceMock.Setup(a => a.GetSettings(It.IsAny<IConfiguration>())).Returns(new KeyValueConfigurationCollection());
            appConfigServiceMock.Setup(a => a.SaveConfiguration(It.IsAny<IConfiguration>())).Returns(new ServiceOperationResult(OperationResult.Success));
            appConfigServiceMock.Setup(a => a.RefreshConfigurationSettings()).Returns(new ServiceOperationResult(OperationResult.Success));

            var gacService = new GacutilLocationService(appConfigServiceMock.Object);
            var result = gacService.Save(String.Empty);

            Assert.AreEqual(OperationResult.Success, result.Result); 
        }

        [TestMethod]
        public void Save_AppServiceKeyExist_ReturnServiceOperationResult()
        {
            throw new NotImplementedException(); 
        }

        [TestMethod]
        public void Save_Failed_ReturnServiceOperationResult()
        {
            Mock<IConfiguration> configurationMock = new Mock<IConfiguration>();

            Mock<IApplicationConfigurationService> appConfigServiceMock = new Mock<IApplicationConfigurationService>();
            appConfigServiceMock.Setup(a => a.GetConfiguration()).Returns(configurationMock.Object);
            appConfigServiceMock.Setup(a => a.GetSettings(It.IsAny<IConfiguration>())).Returns(new KeyValueConfigurationCollection());
            appConfigServiceMock.Setup(a => a.SaveConfiguration(It.IsAny<IConfiguration>())).Returns(new ServiceOperationResult(OperationResult.Failed));
            appConfigServiceMock.Setup(a => a.RefreshConfigurationSettings()).Returns(new ServiceOperationResult(OperationResult.Success));

            var gacService = new GacutilLocationService(appConfigServiceMock.Object);
            var result = gacService.Save(String.Empty);

            Assert.AreEqual(OperationResult.Failed, result.Result);
        }
    }
}
