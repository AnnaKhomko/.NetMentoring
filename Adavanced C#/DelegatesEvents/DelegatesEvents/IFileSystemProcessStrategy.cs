using DelegatesEvents.EventArguments;
using DelegatesEvents.Wrappers.Interfaces;
using System;

namespace DelegatesEvents
{
    public interface IFileSystemProcessStrategy
    {
        ActionType ProcessItemFinded<TItemInfo>(
            TItemInfo itemInfo,
            Func<IFileSystemInfoWrapper, bool> filterFunc,
            EventHandler<FilteredAndFindedEventArgs<TItemInfo>> itemFinded,
            EventHandler<FilteredAndFindedEventArgs<TItemInfo>> itemfiltered,
            Action<EventHandler<FilteredAndFindedEventArgs<TItemInfo>>, FilteredAndFindedEventArgs<TItemInfo>> eventEmitter)
            where TItemInfo : IFileSystemInfoWrapper;
    }
}
