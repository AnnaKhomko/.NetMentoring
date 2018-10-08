using DelegatesEvents.EventArguments;
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
        public event EventHandler<FilteredAndFindedEventArgs<FileInfo>> fileFindedEvent;
        public event EventHandler<FilteredAndFindedEventArgs<DirectoryInfo>> directoryFindedEvent;
        public event EventHandler<FilteredAndFindedEventArgs<FileInfo>> fileFilteredEvent;
        public event EventHandler<FilteredAndFindedEventArgs<DirectoryInfo>> directoryFilteredEvent;

        private readonly FIleSystemProcessStartegy fileSystemProcessingStrategy;

        public FileSystemVisitor(Func<FileSystemInfo, bool> filterFunc)
        {
            this.filterFunc = filterFunc;
            fileSystemProcessingStrategy = new FIleSystemProcessStartegy();
        }

        public void StartProcess(string startPoint)
        {
            startEvent?.Invoke(this, new SystemVisitorArgs());
            var list = GetFileSystemTree(startPoint, CurrentAction.ContinueSearch);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            finishEvent?.Invoke(this, new SystemVisitorArgs());
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
                FileInfoEventHandling(item);

                if (filterFunc.Invoke(item))
                {
                    if (item is FileInfo)
                    {
                        InvokeFileFilteredEvent(currentAction, item);
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
                        InvokeDirectoryFilteredEvent(currentAction, item);
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

        private void InvokeDirectoryFilteredEvent(CurrentAction currentAction, FileSystemInfo item)
        {
            var args = new FilteredAndFindedEventArgs<DirectoryInfo>(currentAction.Action, item);
            directoryFilteredEvent?.Invoke(this, args);
            currentAction.Action = args.Action;
        }

        private void InvokeFileFilteredEvent(CurrentAction currentAction, FileSystemInfo item)
        {
            var args = new FilteredAndFindedEventArgs<FileInfo>(currentAction.Action, item);
            fileFilteredEvent?.Invoke(this, args);
            currentAction.Action = args.Action;
        }

        private void FileInfoEventHandling(FileSystemInfo item)
        {
            if (item is FileInfo)
            {
                fileFindedEvent?.Invoke(this, new FilteredAndFindedEventArgs<FileInfo>(item));
            }
            else if (item is DirectoryInfo)
            {
                directoryFindedEvent?.Invoke(this, new FilteredAndFindedEventArgs<DirectoryInfo>(item));
            }
        }

        /*private ActionType ProcessFile(FileInfo file)
        {
            return _fileSystemProcessingStrategy
                .ProcessItemFinded(file, fileFilteredEvent);
        }

        private ActionType ProcessDirectory(DirectoryInfo directory)
        {
            return _fileSystemProcessingStrategy
                .ProcessItemFinded(directory, directoryFilteredEvent);
        }*/

        private class CurrentAction
        {
            public ActionType Action { get; set; }
            public static CurrentAction ContinueSearch
                => new CurrentAction { Action = ActionType.Continue };
        }
    }
}
