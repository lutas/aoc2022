namespace VFS;

public class VirtualDirectory : IVirtualObject
{
    public string Name { get; private set; }
    private readonly List<IVirtualObject> _children;
    private readonly VirtualDirectory? _parent;

    public VirtualDirectory? Parent => _parent;
    public IEnumerable<IVirtualObject> Children => _children;

    public VirtualDirectory(string name)
    {
        Name = name;
        _children = new List<IVirtualObject>();
        _parent = null;
    }

    public VirtualDirectory(VirtualDirectory parent, string name)
    {
        Name = name;
        _children = new List<IVirtualObject>();
        _parent = parent;
    }

    public VirtualDirectory AddDirectory(string name)
    {
        var child = new VirtualDirectory(this, name);
        _children.Add(child);

        return child;
    }

    public VirtualFile AddFile(string name, int fileSize)
    {
        var child = new VirtualFile(name, fileSize);
        _children.Add(child);

        return child;
    }

    public int CalculateTotalSize()
    {
        int total = _children.Sum(obj => obj.CalculateTotalSize());
        return total;
    }

    public VirtualDirectory? GetSubDirectory(string name)
    {
        return _children.OfType<VirtualDirectory>().SingleOrDefault(i => i.Name == name);
    }

    public override string ToString()
    {
        return Name;
    }
}