namespace VFS;

public class VirtualFileSystem : IVirtualObject {

    const int DefaultDiskSpace = 70000000;

    public VirtualDirectory Cwd { get; private set; }
    public VirtualDirectory Root { get; private set; }

    private readonly int _totalDiskSpace;

    public string Name => ((IVirtualObject)Root).Name;

    public VirtualFileSystem() : this(DefaultDiskSpace) {}

    public VirtualFileSystem(int totalDiskSpace)
    {
        Root = new VirtualDirectory("/");
        Cwd = Root;
        _totalDiskSpace = totalDiskSpace;
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

    public int CalculateFreeDiskSpace()
    {
        int usedSpace = CalculateTotalSize();
        int freeDiskSpace = _totalDiskSpace - usedSpace;

        return freeDiskSpace;
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

    public VirtualDirectory WhichDirectoryToFreeUp(int requiredSpace)
    {
        int minDataSizeToDelete = requiredSpace - CalculateFreeDiskSpace();

        var directory = GetAllDirectories()
            .Select(dir => {
                int fileSize = dir.CalculateTotalSize();

                return new {
                    dir,
                    fileSize
                };
            })
            .Where(d => d.fileSize >= minDataSizeToDelete)
            .OrderBy(d => d.fileSize)
            .First()
            .dir;

        return directory;
    }
}