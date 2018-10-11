using DelegatesEvents.Wrappers.Interfaces;
using System.IO;

namespace DelegatesEvents
{
    public class FileSystemInfoWrapper : IFileSystemInfoWrapper
    {
        public FileSystemInfo fileSystemInfo;

        public FileSystemInfoWrapper()
        {

        }

        public FileSystemInfoWrapper(FileSystemInfo fileSystemInfo)
        {
            this.fileSystemInfo = fileSystemInfo;
        }

        public string Name { get; set; }
    }
}
