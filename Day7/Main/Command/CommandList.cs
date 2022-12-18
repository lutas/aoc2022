using VFS;

namespace Command;

public class CommandList
{
    private readonly List<string> _commands;
    public IEnumerable<string> Commands => _commands;

    public CommandList(VirtualFileSystem fileSystem)
    {
        _commands = new List<string>();
    }
}
