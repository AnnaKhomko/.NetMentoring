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

        private readonly IFileSystemProcessStrategy fileSystemProcessingStrategy;

        public FileSystemVisitor(Func<FileSystemInfo, bool> filterFunc)
        {
            this.filterFunc = filterFunc;
            fileSystemProcessingStrategy = new FileSystemProcessStrategy();
        }

        public IEnumerable<FileSystemInfo> StartProcess(DirectoryInfo startDirectory)
        {
            startEvent?.Invoke(this, new SystemVisitorArgs());
            var list = GetFileSystemTree(startDirectory, CurrentAction.ContinueSearch);
            foreach (var item in list)
            {
                yield return item;
            }
            finishEvent?.Invoke(this, new SystemVisitorArgs());
        }

        private IEnumerable<FileSystemInfo> GetFileSystemTree(DirectoryInfo startDirectory, CurrentAction currentAction)
        { 
            FileSystemInfo[] foundFilesAndDirectoriesInPath = startDirectory.GetFileSystemInfos();

            foreach (var item in foundFilesAndDirectoriesInPath)
            {
                if (currentAction.Action == ActionType.Stop)
                {
                    yield break;
                }

                if (item is FileInfo file)
                {
                    currentAction.Action = ProcessFile(file);
                    switch (currentAction.Action)
                    {
                        case ActionType.Continue:
                            {
                                yield return file;
                                break;
                            }
                        case ActionType.Stop:
                            {
                                yield break;
                            }
                    }
                }
                else if (item is DirectoryInfo directory)
                {
                    currentAction.Action = ProcessDirectory(directory);
                    switch (currentAction.Action)
                    {
                        case ActionType.Continue:
                            {
                                yield return directory;
                                foreach (var dir in GetFileSystemTree(directory, currentAction))
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

        private ActionType ProcessFile(FileInfo file)
        {
            return fileSystemProcessingStrategy
                .ProcessItemFinded(file, filterFunc, fileFindedEvent, fileFilteredEvent, OnEvent);
        }

        private ActionType ProcessDirectory(DirectoryInfo directory)
        {
            return fileSystemProcessingStrategy
                .ProcessItemFinded(directory, filterFunc, directoryFindedEvent, directoryFilteredEvent, OnEvent);
        }

        private void OnEvent<TArgs>(EventHandler<TArgs> someEvent, TArgs args)
        {
            someEvent?.Invoke(this, args);
        }

        private class CurrentAction
        {
            public ActionType Action { get; set; }
            public static CurrentAction ContinueSearch
                => new CurrentAction { Action = ActionType.Continue };
        }
    }
}
