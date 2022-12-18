namespace VFS;

public interface IVirtualObject
{
    string Name { get; }

    int CalculateTotalSize();
}