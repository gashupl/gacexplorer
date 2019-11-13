using GacExplorer.Services.DTO;
using GacExplorer.Services.OperationResults;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GacExplorer.Services.Tests
{
    [TestClass]
    public class GacutilOutputParserServiceTest
    {
        private GacutilOutputParserService testedService; 

        [TestInitialize]
        public void OnBeforeMethodExecution()
        {
            this.testedService = new GacutilOutputParserService(); 
        }

        [TestCleanup]
        public void OnAfterMethodExecution()
        {
            this.testedService = null; 
        }

        #region ParseListOutput tests
        [TestMethod]
        public void ParseListOutput_ValidOutput_ReturnSuccessfullResult()
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

            var expectedResult = OperationResult.Success;
            var expectedAssemblyLinesCount = 7;
            var expectedFirstAssemblyLineDto = new AssemblyLineDto()
            {
                Name = "CustomMarshalers",
                Version = "2.0.0.0",
                Culture = "neutral",
                PublicKeyToken = "b03f5f7f11d50a3a",
                ProcessorArchitecture = "AMD64"
            };

            var result = testedService.ParseListOutput(output);

            Assert.AreEqual(expectedResult, result.Result);

            Assert.IsNotNull(result.AssemblyLines);
            Assert.AreEqual(expectedAssemblyLinesCount, result.AssemblyLines.Count);

            Assert.AreEqual(expectedFirstAssemblyLineDto.Name, result.AssemblyLines[0].Name);
            Assert.AreEqual(expectedFirstAssemblyLineDto.Version, result.AssemblyLines[0].Version);
            Assert.AreEqual(expectedFirstAssemblyLineDto.Culture, result.AssemblyLines[0].Culture);
            Assert.AreEqual(expectedFirstAssemblyLineDto.PublicKeyToken, result.AssemblyLines[0].PublicKeyToken);
            Assert.AreEqual(expectedFirstAssemblyLineDto.ProcessorArchitecture, result.AssemblyLines[0].ProcessorArchitecture);

        }

        [TestMethod]
        public void ParseListOutput_InvalidOutput_ReturnNullAssemblyList()
        {
            string output = "Microsoft (R) .NET Global Assembly Cache Utility.  Version 4.0.30319.1\r\n" +
                         "Copyright (c) Microsoft Corporation.  All rights reserved.\r\n\r\n" +
                         "The Global Assembly Cache contains the following assemblies:\r\n  " +
                         "Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=AMD64\r\n  ";

            var expectedResult = OperationResult.Failed;

            var result = testedService.ParseListOutput(output);

            Assert.AreEqual(expectedResult, result.Result);
            Assert.IsNull(result.AssemblyLines);
        }

        [TestMethod]
        public void ParseListOutput_EmptyOutput_ReturnFailedResult()
        {
            string output = String.Empty; 

            var expectedResult = OperationResult.Failed;

            var result = testedService.ParseListOutput(output);

            Assert.AreEqual(expectedResult, result.Result);
            Assert.IsNull(result.AssemblyLines);
        }
        #endregion

        #region ParseRegisterOutput tests
        [TestMethod]
        public void ParseRegisterOutput_ValidOutput_ReturnSuccessfullResult()
        {
            string output = "Microsoft (R) .NET Global Assembly Cache Utility.  Version 4.0.30319.1\r\n"
                + "\r\n"
                + "Copyright(c) Microsoft Corporation.  All rights reserved.\r\n"
                + "Assembly successfully added to the cache";

            var expectedResult = OperationResult.Success;

            var result = testedService.ParseRegisterOutput(output);

            Assert.AreEqual(expectedResult, result.Result);
        }

        [TestMethod]
        public void ParseRegisterOutput_EmptyOutput_ReturnFailedResult()
        {
            string output = String.Empty; 

            var expectedResult = OperationResult.Failed;

            var result = testedService.ParseRegisterOutput(output);

            Assert.AreEqual(expectedResult, result.Result);
        }

        [TestMethod]
        public void ParseRegisterOutput_InvalidOutput_ReturnFailedResult()
        {
            string output = "Microsoft (R) .NET Global Assembly Cache Utility.  Version 4.0.30319.1\r\n"
                + "Copyright(c) Microsoft Corporation.  All rights reserved.\r\n"
                + "\r\n"
                + "Failure adding assembly to the cache: Attempt to install an assembly without a strong name\r\n"; 

            var expectedResult = OperationResult.Failed;

            var result = testedService.ParseRegisterOutput(output);

            Assert.AreEqual(expectedResult, result.Result);
        }
        #endregion

        #region ParseUnregisterOutput tests

        [TestMethod]
        public void ParseUnregisterOutput_EmptyOutput_ReturnFailedResult()
        {
            string output = String.Empty;

            var expectedResult = OperationResult.Failed;

            var result = testedService.ParseUnregisterOutput(output);

            Assert.AreEqual(expectedResult, result.Result);
        }

        [TestMethod]
        public void ParseUnegisterOutput_InvalidOutput_ReturnFailedResult()
        {
            string output = "Microsoft(R) .NET Global Assembly Cache Utility.Version 4.0.30319.1\r\n" 
                + "Copyright(c) Microsoft Corporation.All rights reserved.\r\n" 
                + "\r\n" 
                + "No assemblies found matching: GacExplorer.TestLibrary.dll\r\n" 
                + "Number of assemblies uninstalled = 0\r\n" 
                + "Number of failures = 0\r\n";

            var expectedResult = OperationResult.Failed;

            var result = testedService.ParseRegisterOutput(output);

            Assert.AreEqual(expectedResult, result.Result);
        }

        [TestMethod]
        public void ParseUnregisterOutput_ValidOutput_ReturnSuccessfullResult()
        {
            string output = "Microsoft(R) .NET Global Assembly Cache Utility.Version 4.0.30319.1\r\n"
                + "Copyright(c) Microsoft Corporation.All rights reserved.\r\n"
                + "\r\n"
                + "Assembly: GacExplorer.TestLibrary, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = a5a2561c243b4c06, processorArchitecture = MSIL\r\n"
                + "Uninstalled: GacExplorer.TestLibrary, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = a5a2561c243b4c06, processorArchitecture = MSIL\r\n"
                + "Number of assemblies uninstalled = 1\r\n"
                + "Number of failures = 0";

            var expectedResult = OperationResult.Success;

            var result = testedService.ParseUnregisterOutput(output);

            Assert.AreEqual(expectedResult, result.Result);
        }
        #endregion

    }
}
