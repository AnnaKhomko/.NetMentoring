using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents
{
    public class SystemVisitorArgs : EventArgs
    {
        public ActionType Action { get; set; } 
        public FileSystemInfo Item { get; set; }

        public SystemVisitorArgs() { }
        public SystemVisitorArgs(FileSystemInfo item)
        {
            Item = item;
        }
        public SystemVisitorArgs(ActionType type, FileSystemInfo item)
        {
            Action = type;
            Item = item;
        }
    }
}
