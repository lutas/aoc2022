namespace Tests;

using VFS;

public class CommandTests 
{[Fact]
    public void Can_Parse_CD()
    {
        var commands = new string[] { "$ cd /", "$ cd test" };
        var vfs = new VirtualFileSystem();
        vfs.Root.AddDirectory("test");
        var command = new Command.Parser(vfs);

        command.Parse(commands);

        vfs.Cwd.Name.ShouldBe("test");
    }

    [Fact]
    public void Creates_Directory_From_LS_Command()
    {
        var commands = new string[] { "$ cd /", "$ ls", "dir a" };
        var vfs = new VirtualFileSystem();
        var command = new Command.Parser(vfs);

        command.Parse(commands);
        
        var childDirectory = vfs.Root.Children.Take(1).Single();

        childDirectory.Name.ShouldBe("a");
    }

    [Fact]
    public void Can_Handle_Unexpected_Command()
    {
        var commands = new string[] { "foo", "$ bar", "$ baz" };
        var vfs = new VirtualFileSystem();
        var command = new Command.Parser(vfs);

        Should.Throw<ApplicationException>(() => command.Parse(commands));
    }

    [Fact]
    public void Can_Parse_Up_A_Directory()
    {
        var commands = new string[] { "$ cd /", "$ ls", "dir a", 
                                        "$ cd a", "$ ls", "dir b",
                                        "$ cd b", "$ cd .." };
        var vfs = new VirtualFileSystem();
        var command = new Command.Parser(vfs);
        command.Parse(commands);

        string currentDirectory = vfs.Cwd.Name;

        currentDirectory.ShouldBe("a");
    }
        
    [Fact]
    public void Can_Calculate_Individual_Sizes()
    {
        var commands = new string[] { "$ cd /", "$ ls", "dir Test", "dir Test2", 
                                        "$ cd Test", "$ ls", "dir Subdir", "100 File1", "150 File2",
                                        "$ cd Subdir", "$ ls", "300 File3",
                                        "$ cd ..", "$ cd ..",
                                        "$ cd Test2", "$ ls", "2000 File4" };
        var vfs = new VirtualFileSystem();
        var command = new Command.Parser(vfs);
        command.Parse(commands);
        
        var dir = vfs.Root.GetSubDirectory("Test")!;
        var subdir = dir.GetSubDirectory("Subdir")!;

        var testFileSize = dir.CalculateTotalSize();
        var subdirFileSize = subdir.CalculateTotalSize();

        testFileSize.ShouldBe(550);
        subdirFileSize.ShouldBe(300);        
    }
}