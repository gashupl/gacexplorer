using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GacExplorer.CommandProxy;
using GacExplorer.Services.OperationResults;
using Moq;

namespace GacExplorer.Services.Tests
{
    [TestClass]
    public class GlobalAssemblyCacheServiceTest: ServiceTestBase
    {
        #region GetAssemblyLines tests
        [TestMethod]
        public void GetAssemblyLines_ValidOutput_ReturnSucessGetAssemblyLinesOperationResult()
        {

            string output = "Microsoft (R) .NET Global Assembly Cache Utility.  Version 4.0.30319.1\r\n" +
                "Copyright (c) Microsoft Corporation.  All rights reserved.\r\n\r\n" +
                "The Global Assembly Cache contains the following assemblies:\r\n  " +
                "CustomMarshalers, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=AMD64\r\n  " +
                "ISymWrapper, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=AMD64\r\n  " +
                "Microsoft.BitLockerManagement.WmiProviders, Version=2.5.1100.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=AMD64\r\n  " +
                "Microsoft.Ink, Version=6.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=AMD64\r\n  " +
                "Microsoft.Interop.Security.AzRoles, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=AMD64\r\n  " +
                "Microsoft.SqlServer.BatchParser, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91, processorArchitecture=AMD64\r\n  " +
                "Microsoft.SqlServer.GridControl, Version=10.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91, processorArchitecture=AMD64\r\n"; 

            var gacProxyMock = new Mock<IGacutil>();
            gacProxyMock.Setup(m => m.ListAssemblies()).Returns(output); 

            var outputParserMock = new Mock<IGacutilOutputParserService>();
            outputParserMock.Setup(m => m.ParseListOutput(It.IsAny<string>()))
                .Returns(new GacutilOutputParserResult(OperationResult.Success));
            var service = new GlobalAssemblyCacheService(gacProxyMock.Object, outputParserMock.Object, Log);

            var response = service.GetAssemblyLines();
            Assert.AreEqual(OperationResult.Success, response.Result);
        }

        [TestMethod]
        public void GetAssemblyLines_InvalidOutput_ReturnFailedGetAssemblyLinesOperationResult()
        {
            string output = "Invalid output";

            var gacProxyMock = new Mock<IGacutil>();
            gacProxyMock.Setup(m => m.ListAssemblies()).Returns(output);

            var outputParserMock = new Mock<IGacutilOutputParserService>();
            outputParserMock.Setup(m => m.ParseListOutput(It.IsAny<string>()))
                .Returns(new GacutilOutputParserResult(OperationResult.Failed));

            var service = new GlobalAssemblyCacheService(gacProxyMock.Object, outputParserMock.Object, Log);

            var response = service.GetAssemblyLines();
            Assert.AreEqual(OperationResult.Failed, response.Result);
        }

        [TestMethod]
        public void GetAssemblyLines_EmptyOutput_ReturnFailedGetAssemblyLinesOperationResult()
        {
            string output = String.Empty; 

            var gacProxyMock = new Mock<IGacutil>();
            gacProxyMock.Setup(m => m.ListAssemblies()).Returns(output);

            var outputParserMock = new Mock<IGacutilOutputParserService>();
            outputParserMock.Setup(m => m.ParseListOutput(It.IsAny<string>()))
                .Returns(new GacutilOutputParserResult(OperationResult.Failed));

            var service = new GlobalAssemblyCacheService(gacProxyMock.Object, outputParserMock.Object, Log);

            var response = service.GetAssemblyLines();
            Assert.AreEqual(OperationResult.Failed, response.Result);
        }
        #endregion

        #region RegisterAssembly tests
        [TestMethod]
        public void RegisterAssembly_ValidAssembly_ReturnSuccessfullServiceResult()
        {
            string output = String.Empty;
            string path = String.Empty;

            var expectedResult = OperationResult.Success; 

            var gacProxyMock = new Mock<IGacutil>();
            gacProxyMock.Setup(m => m.RegisterAssembly(It.IsAny<string>())).Returns(output);

            var outputParserMock = new Mock<IGacutilOutputParserService>();
            outputParserMock.Setup(m => m.ParseRegisterOutput(It.IsAny<string>()))
                .Returns(new ServiceOperationResult(OperationResult.Success));

            var service = new GlobalAssemblyCacheService(gacProxyMock.Object, outputParserMock.Object, Log);

            var response = service.RegisterAssembly(path);

            Assert.AreEqual(expectedResult, response.Result); 
        }

        [TestMethod]
        public void RegisterAssembly_InvalidAssembly_ReturnFailedServiceResult()
        {
            string output = String.Empty;
            string path = String.Empty;

            var expectedResult = OperationResult.Failed;

            var gacProxyMock = new Mock<IGacutil>();
            gacProxyMock.Setup(m => m.RegisterAssembly(It.IsAny<string>())).Returns(output);

            var outputParserMock = new Mock<IGacutilOutputParserService>();
            outputParserMock.Setup(m => m.ParseRegisterOutput(It.IsAny<string>()))
                .Returns(new ServiceOperationResult(OperationResult.Failed));

            var service = new GlobalAssemblyCacheService(gacProxyMock.Object, outputParserMock.Object, Log);

            var response = service.RegisterAssembly(path);

            Assert.AreEqual(expectedResult, response.Result);
        }
        #endregion

        #region UnregisterAssembly tests
        [TestMethod]
        public void UnregisterAssembly_ValidAssembly_ReturnSuccessfullServiceResult()
        {
            string output = String.Empty;
            string path = String.Empty;

            var expectedResult = OperationResult.Success;

            var gacProxyMock = new Mock<IGacutil>();
            gacProxyMock.Setup(m => m.UnregisterAssembly(It.IsAny<string>())).Returns(output);

            var outputParserMock = new Mock<IGacutilOutputParserService>();
            outputParserMock.Setup(m => m.ParseUnregisterOutput(It.IsAny<string>()))
                .Returns(new ServiceOperationResult(OperationResult.Success));

            var service = new GlobalAssemblyCacheService(gacProxyMock.Object, outputParserMock.Object, Log);

            var response = service.UnregisterAssembly(path);

            Assert.AreEqual(expectedResult, response.Result);
        }

        [TestMethod]
        public void UnregisterAssembly_InvalidAssembly_ReturnFailedServiceResult()
        {
            string output = String.Empty;
            string path = String.Empty;

            var expectedResult = OperationResult.Failed;

            var gacProxyMock = new Mock<IGacutil>();
            gacProxyMock.Setup(m => m.UnregisterAssembly(It.IsAny<string>())).Returns(output);

            var outputParserMock = new Mock<IGacutilOutputParserService>();
            outputParserMock.Setup(m => m.ParseUnregisterOutput(It.IsAny<string>()))
                .Returns(new ServiceOperationResult(OperationResult.Failed));

            var service = new GlobalAssemblyCacheService(gacProxyMock.Object, outputParserMock.Object, Log);

            var response = service.UnregisterAssembly(path);

            Assert.AreEqual(expectedResult, response.Result);
        }
        #endregion
    }
}
