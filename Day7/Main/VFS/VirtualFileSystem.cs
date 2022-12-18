namespace VFS;

public class VirtualFileSystem : IVirtualObject {

    public VirtualDirectory Cwd { get; private set; }
    public VirtualDirectory Root { get; private set; }

    public string Name => ((IVirtualObject)Root).Name;

    public VirtualFileSystem()
    {
        Root = new VirtualDirectory("/");
        Cwd = Root;
    }

    public bool CD(string path)
    {
        if (path == "/")
        {
            Cwd = Root;
            return true;
        }

        if (path == "..")
        {
            UpDirectory();
            return true;
        }

        var subdir = Cwd.GetSubDirectory(path);
        if (subdir == null)
        {
            return false;
        }

        Cwd = subdir;
        return true;
    }

    public int CalculateTotalSize()
    {
        return ((IVirtualObject)Root).CalculateTotalSize();
    }

    public int CalculateTotalSizeLimit(int maxSize)
    {
        var flattenedDirectories = GetAllDirectories().Select(dir => {

            int fileSize = dir.CalculateTotalSize();

            return new {
                dir.Name,
                fileSize
            };
        });

        var totalSize = flattenedDirectories.Where(data => data.fileSize <= maxSize)
                            .Select(d => d.fileSize)
                            .Sum();
                            
        return totalSize;
    }

    public void UpDirectory()
    {
        Cwd = Cwd.Parent ?? Root;
    }

    private IEnumerable<VirtualDirectory> GetAllDirectories()
    {
        var stack = new Stack<IVirtualObject>();
        stack.Push(Root);
        while (stack.Any())
        {
            var next = stack.Pop() as VirtualDirectory;
            if (next != null)
            {
                yield return next;
                foreach (var subdir in next.Children)
                {
                    stack.Push(subdir);
                }
            }
        }
    }
}