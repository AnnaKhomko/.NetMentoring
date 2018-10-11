namespace DelegatesEvents.Wrappers.Interfaces
{
    public interface IDirectoryInfoWrapper : IFileSystemInfoWrapper
    {
        IFileSystemInfoWrapper[] GetFileSystemInfos();
    }
}
