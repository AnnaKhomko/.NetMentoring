using DelegatesEvents.EventArguments;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents
{
    public interface IFileSystemProcessStrategy
    {
        ActionType ProcessItemFinded<TItemInfo>(
            TItemInfo itemInfo,
            Func<FileSystemInfo, bool> filterFunc,
            EventHandler<FilteredAndFindedEventArgs<TItemInfo>> itemFinded,
            EventHandler<FilteredAndFindedEventArgs<TItemInfo>> itemfiltered,
            Action<EventHandler<FilteredAndFindedEventArgs<TItemInfo>>, FilteredAndFindedEventArgs<TItemInfo>> eventEmitter)
            where TItemInfo : FileSystemInfo;
    }
}
