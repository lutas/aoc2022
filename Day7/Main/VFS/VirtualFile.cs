namespace VFS;

public class VirtualFile : IVirtualObject
{
    public string Name { get; private set; }
    public int FileSize { get; private set; }

    public VirtualFile(string name, int filesize)
    {
        Name = name;
        FileSize = filesize;
    }

    public int CalculateTotalSize() 
    {
        return FileSize;
    }

    public override string ToString()
    {
        return Name;
    }
}