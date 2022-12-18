namespace Tests;

using Command;
using VFS;

public class CoreTests
{
    public static string[] ExampleData = new string[] {
        "$ cd /",
        "$ ls",
        "dir a",
        "14848514 b.txt",
        "8504156 c.dat",
        "dir d",
        "$ cd a",
        "$ ls",
        "dir e",
        "29116 f",
        "2557 g",
        "62596 h.lst",
        "$ cd e",
        "$ ls",
        "584 i",
        "$ cd ..",
        "$ cd ..",
        "$ cd d",
        "$ ls",
        "4060174 j",
        "8033020 d.log",
        "5626152 d.ext",
        "7214296 k"
    };

    [Fact]
    public void Can_Calculate_TotalSize()
    {
        var fileSystem = new VirtualFileSystem();
        var commands = new Command.Parser(fileSystem);
        commands.Parse(ExampleData);

        var totalSize = fileSystem.Root.CalculateTotalSize();

        totalSize.ShouldBe(48381165);
    }

    [Fact]
    public void Can_Calculate_Total_Size_Of_Directories_LessThanEqual_100000()
    {
        var fileSystem = new VirtualFileSystem();
        var commands = new Command.Parser(fileSystem);
        commands.Parse(ExampleData);

        var totalSize = fileSystem.CalculateTotalSizeLimit(100000);

        totalSize.ShouldBe(95437);
    }
}