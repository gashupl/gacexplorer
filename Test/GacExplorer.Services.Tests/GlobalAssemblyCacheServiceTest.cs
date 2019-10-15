﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class GlobalAssemblyCacheServiceTest
    {
        [TestMethod]
        public void GetAssemblyLines_ValidOutput_ReturnSucessGetAssemblyLinesOperationResult()
        {
            var expectedLines = 50;

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

            var outputParser = new GacutilOutputParserService(); 
            var service = new GlobalAssemblyCacheService(gacProxyMock.Object, outputParser);
            var response = service.GetAssemblyLines();
            Assert.AreEqual(OperationResult.Success, response.Result);
            Assert.AreEqual(expectedLines, response.AssemblyLines.Count);
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