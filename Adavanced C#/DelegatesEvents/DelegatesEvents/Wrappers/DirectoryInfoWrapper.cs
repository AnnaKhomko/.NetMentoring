using DelegatesEvents.Wrappers.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace DelegatesEvents.Wrappers
{
    public class DirectoryInfoWrapper : IDirectoryInfoWrapper
    {
        private DirectoryInfo directory;

        public DirectoryInfoWrapper()
        {

        }

        public DirectoryInfoWrapper(DirectoryInfo directory)
        {
            this.directory = directory;
        }

        public IFileSystemInfoWrapper[] GetFileSystemInfos()
        {
            FileInfo[] result = directory.GetFiles();

            var list = new List<IFileSystemInfoWrapper>();

            foreach (var item in result)
            {
                list.Add(new FileSystemInfoWrapper(item));
            }

            return list.ToArray();
        }

        public string Name { get; set; }
    }
}
