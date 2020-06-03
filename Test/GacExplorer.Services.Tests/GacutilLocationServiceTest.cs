using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using GacExplorer.Services.Wrappers;
using GacExplorer.Services.OperationResults;


namespace GacExplorer.Services.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class GacutilLocationServiceTest : ServiceTestBase
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

            var gacService = new GacutilLocationService(appConfigServiceMock.Object, null, Log);
            var result = gacService.Save(String.Empty);

            Assert.AreEqual(OperationResult.Success, result.Result); 
        }

        [TestMethod]
        public void Save_AppServiceKeyExist_ReturnServiceOperationResult()
        {
            Mock<IConfiguration> configurationMock = new Mock<IConfiguration>();

            Mock<IApplicationConfigurationService> appConfigServiceMock = new Mock<IApplicationConfigurationService>();
            appConfigServiceMock.Setup(a => a.GetConfiguration()).Returns(configurationMock.Object);
            appConfigServiceMock.Setup(a => a.GetSettings(It.IsAny<IConfiguration>()))
                .Returns(new KeyValueConfigurationCollection() { new KeyValueConfigurationElement(GacutilLocationService.LocationKey, String.Empty) });
            appConfigServiceMock.Setup(a => a.SaveConfiguration(It.IsAny<IConfiguration>())).Returns(new ServiceOperationResult(OperationResult.Success));
            appConfigServiceMock.Setup(a => a.RefreshConfigurationSettings()).Returns(new ServiceOperationResult(OperationResult.Success));

            var gacService = new GacutilLocationService(appConfigServiceMock.Object, null, Log);
            var result = gacService.Save(String.Empty);

            Assert.AreEqual(OperationResult.Success, result.Result);
        }

        [TestMethod]
        public void Save_FailedSave_ReturnServiceOperationResult()
        {
            Mock<IConfiguration> configurationMock = new Mock<IConfiguration>();

            Mock<IApplicationConfigurationService> appConfigServiceMock = new Mock<IApplicationConfigurationService>();
            appConfigServiceMock.Setup(a => a.GetConfiguration()).Returns(configurationMock.Object);
            appConfigServiceMock.Setup(a => a.GetSettings(It.IsAny<IConfiguration>())).Returns(new KeyValueConfigurationCollection());
            appConfigServiceMock.Setup(a => a.SaveConfiguration(It.IsAny<IConfiguration>())).Returns(new ServiceOperationResult(OperationResult.Failed));
            appConfigServiceMock.Setup(a => a.RefreshConfigurationSettings()).Returns(new ServiceOperationResult(OperationResult.Success));

            var gacService = new GacutilLocationService(appConfigServiceMock.Object, null, Log);
            var result = gacService.Save(String.Empty);

            Assert.AreEqual(OperationResult.Failed, result.Result);
        }

        [TestMethod]
        public void Save_FailedRefresh_ReturnServiceOperationResult()
        {
            Mock<IConfiguration> configurationMock = new Mock<IConfiguration>();

            Mock<IApplicationConfigurationService> appConfigServiceMock = new Mock<IApplicationConfigurationService>();
            appConfigServiceMock.Setup(a => a.GetConfiguration()).Returns(configurationMock.Object);
            appConfigServiceMock.Setup(a => a.GetSettings(It.IsAny<IConfiguration>())).Returns(new KeyValueConfigurationCollection());
            appConfigServiceMock.Setup(a => a.SaveConfiguration(It.IsAny<IConfiguration>())).Returns(new ServiceOperationResult(OperationResult.Success));
            appConfigServiceMock.Setup(a => a.RefreshConfigurationSettings()).Returns(new ServiceOperationResult(OperationResult.Failed));

            var gacService = new GacutilLocationService(appConfigServiceMock.Object, null, Log);
            var result = gacService.Save(String.Empty);

            Assert.AreEqual(OperationResult.Failed, result.Result);
        }

        [TestMethod]
        public void Read_LocationFound_ReturnSuccessOperationResultWithLocation()
        {
            string expectedLocation = @"c:\Test\gacutil.exe";
            Mock<IConfiguration> configurationMock = new Mock<IConfiguration>();

            Mock<IApplicationConfigurationService> appConfigServiceMock = new Mock<IApplicationConfigurationService>();
            appConfigServiceMock.Setup(a => a.GetConfiguration()).Returns(configurationMock.Object);
            appConfigServiceMock.Setup(a => a.GetSettings(It.IsAny<IConfiguration>()))
                .Returns(new KeyValueConfigurationCollection() { new KeyValueConfigurationElement(GacutilLocationService.LocationKey, expectedLocation) });
            appConfigServiceMock.Setup(a => a.SaveConfiguration(It.IsAny<IConfiguration>())).Returns(new ServiceOperationResult(OperationResult.Success));
            appConfigServiceMock.Setup(a => a.RefreshConfigurationSettings()).Returns(new ServiceOperationResult(OperationResult.Success));

            var gacService = new GacutilLocationService(appConfigServiceMock.Object, null, Log);
            var result = gacService.Read(); 

            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.AreEqual(expectedLocation, result.Location);
        }

        [TestMethod]
        public void Read_LocationNotFound_ReturnSucessOperationResult()
        {
            Mock<IConfiguration> configurationMock = new Mock<IConfiguration>();

            Mock<IApplicationConfigurationService> appConfigServiceMock = new Mock<IApplicationConfigurationService>();
            appConfigServiceMock.Setup(a => a.GetConfiguration()).Returns(configurationMock.Object);
            appConfigServiceMock.Setup(a => a.GetSettings(It.IsAny<IConfiguration>())).Returns(new KeyValueConfigurationCollection());
            appConfigServiceMock.Setup(a => a.SaveConfiguration(It.IsAny<IConfiguration>())).Returns(new ServiceOperationResult(OperationResult.Success));
            appConfigServiceMock.Setup(a => a.RefreshConfigurationSettings()).Returns(new ServiceOperationResult(OperationResult.Failed));

            var gacService = new GacutilLocationService(appConfigServiceMock.Object, null, Log);
            var result = gacService.Read();

            Assert.AreEqual(OperationResult.Success, result.Result);
            Assert.IsNull(result.Location);
        }

        [TestMethod]
        public void FileExists_ReturnsTrue()
        {
            Mock<IFile> fileMock = new Mock<IFile>();
            fileMock.Setup(f => f.FileExists(It.IsAny<string>())).Returns(true); 

            var gacService = new GacutilLocationService(null, fileMock.Object, Log);
            var result = gacService.FileExists(@"C:\File\gacutil.exe");

            Assert.IsTrue(result); 
        }

        [TestMethod]
        public void FileExists_ReturnsFalse()
        {
            Mock<IFile> fileMock = new Mock<IFile>();
            fileMock.Setup(f => f.FileExists(It.IsAny<string>())).Returns(false);

            var gacService = new GacutilLocationService(null, fileMock.Object, Log);
            var result = gacService.FileExists(@"C:\File\gacutil.exe");

            Assert.IsFalse(result);
        }
    }
}
