using DelegatesEvents.EventArguments;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents
{
    public class FIleSystemProcessStartegy
    {
        public ActionType ProcessItem<TItemInfo>(
            TItemInfo itemInfo,
            EventHandler<FilteredAndFindedEventArgs<TItemInfo>> filteredItemFinded)
            where TItemInfo : FileSystemInfo
        {
            FilteredAndFindedEventArgs<TItemInfo> args = new FilteredAndFindedEventArgs<TItemInfo>
            {
                Item = itemInfo,
                Action = ActionType.Continue
            };
        }
    }
}
