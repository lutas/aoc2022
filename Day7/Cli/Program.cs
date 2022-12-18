// See https://aka.ms/new-console-template for more information
using VFS;
using Command;

var data = System.IO.File.ReadAllLines("Cli/Input.txt");

var vfs = new VirtualFileSystem();
var parser = new Command.Parser(vfs);

parser.Parse(data);

var fileSize = vfs.CalculateTotalSizeLimit(100000);

Console.WriteLine($"Answer was {fileSize}");
