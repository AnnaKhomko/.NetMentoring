using DelegatesEvents.Wrappers.Interfaces;
using System;

namespace DelegatesEvents.EventArguments
{
    public class FilteredAndFindedEventArgs<T> : EventArgs where T : IFileSystemInfoWrapper
    {
        public ActionType Action { get; set; }
        public IFileSystemInfoWrapper Item { get; set; }

        public FilteredAndFindedEventArgs() { }
        public FilteredAndFindedEventArgs(IFileSystemInfoWrapper item)
        {
            Item = item;
        }
        public FilteredAndFindedEventArgs(ActionType type, IFileSystemInfoWrapper item)
        {
            Action = type;
            Item = item;
        }
    }
}
