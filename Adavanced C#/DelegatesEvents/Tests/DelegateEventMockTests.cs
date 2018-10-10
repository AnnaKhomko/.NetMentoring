using System;
using System.IO;
using DelegatesEvents;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DelegateEventMockTests
    {
        private IFileSystemProcessStrategy fileSystemProcessingStrategy;
        private Mock<DirectoryInfo> directoryInfoMock;

        [SetUp]
        public void TestInit()
        {
            fileSystemProcessingStrategy = new FileSystemProcessStrategy();
            directoryInfoMock = new Mock<DirectoryInfo>();
        }
    }
}
