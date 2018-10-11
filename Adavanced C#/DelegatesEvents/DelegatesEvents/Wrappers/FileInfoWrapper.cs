using DelegatesEvents.Wrappers.Interfaces;
using System.IO;

namespace DelegatesEvents.Wrappers
{
    public class FileInfoWrapper : IFileInfoWrapper
    {
        private string fileInfo;
        public FileInfo FileInfo;

        public FileInfoWrapper()
        {

        }

        public FileInfoWrapper(FileInfo fileInfo)
        {
            this.FileInfo = fileInfo;
        }

        public string Name
        {
            get
            {
                if (FileInfo != null)
                {
                    fileInfo = FileInfo.Name;
                }

                return fileInfo;
            }
            set
            {
                fileInfo = value;
            }
        }
    }
}
