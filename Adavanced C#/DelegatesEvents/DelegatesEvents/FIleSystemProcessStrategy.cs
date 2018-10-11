using DelegatesEvents.EventArguments;
using System;
using DelegatesEvents.Wrappers.Interfaces;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents
{
    public class FileSystemProcessStrategy : IFileSystemProcessStrategy
    {
        public ActionType ProcessItemFinded<TItemInfo>(TItemInfo itemInfo,
            Func<IFileSystemInfoWrapper, bool> filterFunc,
            EventHandler<FilteredAndFindedEventArgs<TItemInfo>> itemFinded,
            EventHandler<FilteredAndFindedEventArgs<TItemInfo>> itemfiltered,
            Action<EventHandler<FilteredAndFindedEventArgs<TItemInfo>>, FilteredAndFindedEventArgs<TItemInfo>> eventEmitter) where TItemInfo : IFileSystemInfoWrapper
        {
            var args = new FilteredAndFindedEventArgs<TItemInfo>
            {
                Item = itemInfo,
                Action = ActionType.Continue
            };

            eventEmitter(itemFinded, args);

            if (filterFunc(itemInfo))
            {
                eventEmitter(itemfiltered, args);

                args = new FilteredAndFindedEventArgs<TItemInfo>
                {
                    Item = itemInfo,
                    Action = ActionType.Continue
                };

                return args.Action;
            }

            return ActionType.Skip;
        }
    }
}
