using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents.EventArguments
{
    public class FilteredAndFindedEventArgs<T> : EventArgs where T : FileSystemInfo
    {
        public ActionType Action { get; set; }
        public FileSystemInfo Item { get; set; }

        public FilteredAndFindedEventArgs() { }
        public FilteredAndFindedEventArgs(FileSystemInfo item)
        {
            Item = item;
        }
        public FilteredAndFindedEventArgs(ActionType type, FileSystemInfo item)
        {
            Action = type;
            Item = item;
        }
    }
}
