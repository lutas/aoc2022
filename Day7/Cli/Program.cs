// See https://aka.ms/new-console-template for more information
using VFS;
using Command;

var data = System.IO.File.ReadAllLines("Cli/Input.txt");

int Day1() 
{
    var vfs = new VirtualFileSystem();
    var parser = new Command.Parser(vfs);

    parser.Parse(data);

    var fileSize = vfs.CalculateTotalSizeLimit(100000);

    return fileSize;
}

int Day2() 
{    
    var vfs = new VirtualFileSystem(70000000);
    var parser = new Command.Parser(vfs);

    parser.Parse(data);

    const int RequiredSpace = 30000000;

    var directoryToDelete = vfs.WhichDirectoryToFreeUp(RequiredSpace);
    var directoryToDeleteSize = directoryToDelete.CalculateTotalSize();

    return directoryToDeleteSize;
}

Console.WriteLine($"Day 1 answer {Day1()}");
Console.WriteLine($"Day 2 answer {Day2()}");
