using VFS;

namespace Command;

public class Parser
{
    private const string CDComand = "$ cd";
    private const string LSCommand = "$ ls";

    private VirtualFileSystem _vfs;

    public Parser(VirtualFileSystem vfs)
    {
        _vfs = vfs;
    }

    private void ParseCDCommand(string command)
    {
        string directoryName = command.Substring(CDComand.Length + 1);

        if (!_vfs.CD(directoryName))
        {
            throw new ApplicationException("Unexpected directory " + directoryName);
        }
    }

    private void ParseFileObject(string line) 
    {
        if (line.StartsWith("dir"))
        {
            // "dir abc" = directory named abc
            string directoryName = line.Substring("dir".Length + 1);
            _vfs.Cwd.AddDirectory(directoryName);
        } 
        else 
        {
            // "1234 abc" = file named abc of size 1234
            var data = line.Split(' ');
            if (data.Length != 2) 
            {
                throw new ApplicationException("Unexpected file line found");
            }
            int fileSize;
            if (!int.TryParse(data[0], out fileSize))
            {
                throw new ApplicationException("File line is missing size data");
            }
            string name = data[1];

            _vfs.Cwd.AddFile(name, fileSize);
        }
    }

    public void Parse(IEnumerable<string> lines)
    {        
        foreach (var line in lines)
        {            
            if (line.StartsWith(Parser.CDComand))
            {
                ParseCDCommand(line);
            }
            else if (line.StartsWith(Parser.LSCommand)) 
            {
                // ignore
            }
            else 
            {
                ParseFileObject(line);                
            }
        }

    }
}
