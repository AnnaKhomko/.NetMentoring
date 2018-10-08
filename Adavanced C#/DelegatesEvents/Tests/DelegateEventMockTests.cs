using System;
using System.IO;
using DelegatesEvents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestClass]
    public class DelegateEventMockTests
    {
        [TestFixture]
        public class FileSystemProcessingStrategyTests
        {
            private Mock<FileSystemInfo> _fileSystemInfoMock;

            [SetUp]
            public void TestInit()
            {
                _fileSystemInfoMock = new Mock<FileSystemInfo>();
            }

        }
    }
}
