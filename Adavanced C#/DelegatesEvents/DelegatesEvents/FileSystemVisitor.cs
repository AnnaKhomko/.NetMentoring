using System;
using System.Collections.Generic;
using System.IO;

namespace DelegatesEvents
{
    public class FileSystemVisitor
    {
        private Func<FileSystemInfo, bool> filterFunc;
        public event EventHandler<SystemVisitorArgs> startEvent;
        public event EventHandler<SystemVisitorArgs> finishEvent;
        public event EventHandler<SystemVisitorArgs> fileFindedEvent;
        public event EventHandler<SystemVisitorArgs> directoryFindedEvent;
        public event EventHandler<SystemVisitorArgs> fileFilteredEvent;
        public event EventHandler<SystemVisitorArgs> directoryFilteredEvent;

        public FileSystemVisitor(Func<FileSystemInfo, bool> filterFunc)
        {
            this.filterFunc = filterFunc;
        }

        public void StartProcess(string startPoint)
        {
            startEvent.Invoke(this, new SystemVisitorArgs());
            var list = GetFileSystemTree(startPoint, CurrentAction.ContinueSearch);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            finishEvent.Invoke(this, new SystemVisitorArgs());
        }

        private IEnumerable<FileSystemInfo> GetFileSystemTree(string startPoint, CurrentAction currentAction)
        { 
            DirectoryInfo directoryInfo = new DirectoryInfo(startPoint);
            FileSystemInfo[] foundFilesAndDirectoriesInPath = directoryInfo.GetFileSystemInfos();
            foreach (var item in foundFilesAndDirectoriesInPath)
            {
                if (currentAction.Action == ActionType.Stop)
                {
                    yield break;
                }
                if (item is FileInfo)
                {
                    fileFindedEvent.Invoke(this, new SystemVisitorArgs(item));
                }
                else if (item is DirectoryInfo)
                {
                    directoryFindedEvent.Invoke(this, new SystemVisitorArgs(item));
                }

                if (filterFunc.Invoke(item))
                {
                    if (item is FileInfo)
                    {
                        SystemVisitorArgs args = new SystemVisitorArgs(currentAction.Action, item);
                        fileFilteredEvent.Invoke(this, args);
                        currentAction.Action = args.Action;
                        switch (currentAction.Action)
                        {
                            case ActionType.Continue:
                                {
                                    yield return item;
                                    break;
                                }
                            case ActionType.Stop:
                                {
                                    yield break;
                                }
                        }
                    }

                    else if (item is DirectoryInfo)
                    {
                        SystemVisitorArgs args = new SystemVisitorArgs(currentAction.Action, item);
                        directoryFilteredEvent.Invoke(this, args);
                        currentAction.Action = args.Action;
                        switch (currentAction.Action)
                        {
                            case ActionType.Continue:
                                {
                                    yield return item;
                                    foreach (var dir in GetFileSystemTree(item.FullName, currentAction))
                                    {
                                        yield return dir;
                                    }
                                    break;
                                }
                            case ActionType.Stop:
                                {
                                    yield break;
                                }
                        }
                    }
                }

            }
        }

        private class CurrentAction
        {
            public ActionType Action { get; set; }
            public static CurrentAction ContinueSearch
                => new CurrentAction { Action = ActionType.Continue };
        }
    }
}
