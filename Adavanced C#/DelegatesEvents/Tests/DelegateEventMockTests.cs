using System;
using System.Collections.Generic;
using System.IO;
using DelegatesEvents;
using DelegatesEvents.Wrappers;
using DelegatesEvents.Wrappers.Interfaces;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DelegateEventMockTests
    {
        private IFileSystemProcessStrategy fileSystemProcessingStrategy;
        private Mock<IDirectoryInfoWrapper> directoryInfoMock;

        [SetUp]
        public void TestInit()
        {
            fileSystemProcessingStrategy = new FileSystemProcessStrategy();
            directoryInfoMock = new Mock<IDirectoryInfoWrapper>();
        }

        [Test]
        public void StartProcess_FilterPassed_ExpectedDataReturns()
        {
            var actualList = new List<string>();
            var expectedList = new List<string>()
            {
               "Puppy",
               "HelloWorld"
            };

            var item1 = new Mock<IFileInfoWrapper>();
            var item2 = new Mock<IDirectoryInfoWrapper>();

            item1.Setup(_ => _.Name).Returns("Puppy");
            item2.Setup(_ => _.Name).Returns("HelloWorld");

            var excpectedList = new List<IFileSystemInfoWrapper>()
            {
                item1.Object,
                item2.Object
            };

            directoryInfoMock.Setup(_ => _.GetFileSystemInfos()).Returns(excpectedList.ToArray());

            Func<IFileSystemInfoWrapper, bool> filter = (item) => true;

            var fileSystemVisitor = new FileSystemVisitor(filter);

            foreach (var item in fileSystemVisitor.StartProcess(directoryInfoMock.Object))
            {
                actualList.Add(item.Name);
            }

            CollectionAssert.AreEqual(expectedList, actualList);
            directoryInfoMock.Verify(_ => _.GetFileSystemInfos(), Times.Once);
        }

        [Test]
        public void StartProcess_OnlyOneItemPassFilter_ExpectedDataReturns()
        {
            var actualList = new List<string>();
            var expectedList = new List<string>()
            {
               "Puppy",
            };

            var item1 = new Mock<IFileInfoWrapper>();
            var item2 = new Mock<IDirectoryInfoWrapper>();

            item1.Setup(_ => _.Name).Returns("Puppy");
            item2.Setup(_ => _.Name).Returns("Hello");

            var excpectedList = new List<IFileSystemInfoWrapper>()
            {
                item1.Object,
                item2.Object
            };

            directoryInfoMock.Setup(_ => _.GetFileSystemInfos()).Returns(excpectedList.ToArray());

            Func<IFileSystemInfoWrapper, bool> filter = (item) =>
            {
                return item.Name.Equals("Puppy");
            };

            var fileSystemVisitor = new FileSystemVisitor(filter);

            foreach (var item in fileSystemVisitor.StartProcess(directoryInfoMock.Object))
            {
                actualList.Add(item.Name);
            }

            CollectionAssert.AreEqual(expectedList, actualList);
            directoryInfoMock.Verify(_ => _.GetFileSystemInfos(), Times.Once);
        }

        [Test]
        public void StartProcess_NeitherOfItemsPassFilter_ExpectedDataReturns()
        {
            var actualList = new List<string>();
            var expectedList = new List<string>();

            var item1 = new Mock<IFileInfoWrapper>();
            var item2 = new Mock<IDirectoryInfoWrapper>();

            item1.Setup(_ => _.Name).Returns("Puppy");
            item2.Setup(_ => _.Name).Returns("Hello");

            var excpectedList = new List<IFileSystemInfoWrapper>()
            {
                item1.Object,
                item2.Object
            };

            directoryInfoMock.Setup(_ => _.GetFileSystemInfos()).Returns(excpectedList.ToArray());

            Func<IFileSystemInfoWrapper, bool> filter = (item) => false;

            var fileSystemVisitor = new FileSystemVisitor(filter);

            foreach (var item in fileSystemVisitor.StartProcess(directoryInfoMock.Object))
            {
                actualList.Add(item.Name);
            }

            CollectionAssert.AreEqual(expectedList, actualList);
            directoryInfoMock.Verify(_ => _.GetFileSystemInfos(), Times.Once);
        }
    }
}
