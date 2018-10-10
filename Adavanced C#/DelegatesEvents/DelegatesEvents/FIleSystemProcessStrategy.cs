using DelegatesEvents.EventArguments;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents
{
    public class FileSystemProcessStrategy : IFileSystemProcessStrategy
    {
        public ActionType ProcessItemFinded<TItemInfo>(TItemInfo itemInfo, 
            Func<FileSystemInfo, bool> filterFunc, 
            EventHandler<FilteredAndFindedEventArgs<TItemInfo>> itemFinded, 
            EventHandler<FilteredAndFindedEventArgs<TItemInfo>> itemfiltered,
            Action<EventHandler<FilteredAndFindedEventArgs<TItemInfo>>, FilteredAndFindedEventArgs<TItemInfo>> eventEmitter) where TItemInfo : FileSystemInfo
        {
            FilteredAndFindedEventArgs<TItemInfo> args = new FilteredAndFindedEventArgs<TItemInfo>
            {
                Item = itemInfo,
                Action = ActionType.Continue
            };
            eventEmitter(itemFinded, args);

            if (filterFunc(itemInfo))
            {
                args = new FilteredAndFindedEventArgs<TItemInfo>
                {
                    Item = itemInfo,
                    Action = ActionType.Continue
                };
                eventEmitter(itemfiltered, args);
                return args.Action;
            }
            else return ActionType.Skip;
        }
    }
}
