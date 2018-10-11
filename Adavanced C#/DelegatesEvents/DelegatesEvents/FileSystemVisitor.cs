using DelegatesEvents.EventArguments;
using DelegatesEvents.Wrappers.Interfaces;
using System;
using System.Collections.Generic;

namespace DelegatesEvents
{
    public class FileSystemVisitor
    {
        private Func<IFileSystemInfoWrapper, bool> filter;
        public event EventHandler<SystemVisitorArgs> OnStart;
        public event EventHandler<SystemVisitorArgs> OnFinish;
        public event EventHandler<FilteredAndFindedEventArgs<IFileInfoWrapper>> OnFileFinded;
        public event EventHandler<FilteredAndFindedEventArgs<IDirectoryInfoWrapper>> OnDirectoryFinded;
        public event EventHandler<FilteredAndFindedEventArgs<IFileInfoWrapper>> OnFileFiltered;
        public event EventHandler<FilteredAndFindedEventArgs<IDirectoryInfoWrapper>> OnDirectoryFiltered;

        private readonly IFileSystemProcessStrategy fileSystemProcessingStrategy;

        public FileSystemVisitor(Func<IFileSystemInfoWrapper, bool> filter)
        {
            this.filter = filter;
            fileSystemProcessingStrategy = new FileSystemProcessStrategy();
        }

        public IEnumerable<IFileSystemInfoWrapper> StartProcess(IDirectoryInfoWrapper startDirectory)
        {
            OnEvent(OnStart, new SystemVisitorArgs());

            var list = GetFileSystemTree(startDirectory, CurrentAction.ContinueSearch);
            foreach (var item in list)
            {
                yield return item;
            }

            OnEvent(OnFinish, new SystemVisitorArgs());
        }

        private IEnumerable<IFileSystemInfoWrapper> GetFileSystemTree(IDirectoryInfoWrapper startDirectory, CurrentAction currentAction)
        { 
            IFileSystemInfoWrapper[] foundFilesAndDirectoriesInPath = startDirectory.GetFileSystemInfos();

            foreach (var item in foundFilesAndDirectoriesInPath)
            {
                if (currentAction.Action == ActionType.Stop)
                {
                    yield break;
                }

                if (item is IFileInfoWrapper file)
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
                else if (item is IDirectoryInfoWrapper directory)
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

        private ActionType ProcessFile(IFileInfoWrapper file)
        {
            return fileSystemProcessingStrategy
                .ProcessItemFinded(file, filter, OnFileFinded, OnFileFiltered, OnEvent);
        }

        private ActionType ProcessDirectory(IDirectoryInfoWrapper directory)
        {
            return fileSystemProcessingStrategy
                .ProcessItemFinded(directory, filter, OnDirectoryFinded, OnDirectoryFiltered, OnEvent);
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
