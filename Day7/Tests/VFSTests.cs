namespace Tests;

using VFS;


public class VFSTests
{

    [Fact]
    public void Can_Calculate_Total_Size()
    {
        var fileSystem = new VirtualFileSystem();
        var dir = fileSystem.Root.AddDirectory("Test");
        dir.AddFile("File1", 100);
        dir.AddFile("File2", 150);

        var fileSize = fileSystem.Root.CalculateTotalSize();

        fileSize.ShouldBe(250);
    }
    [Fact]
    public void Can_Calculate_Total_Size_With_SubDirectory()
    {
        var fileSystem = new VirtualFileSystem();
        var dir = fileSystem.Root.AddDirectory("Test");
        dir.AddFile("File1", 100);
        dir.AddFile("File2", 150);
        var subdir = dir.AddDirectory("Subdir");
        subdir.AddFile("File3", 300);

        var fileSize = fileSystem.Root.CalculateTotalSize();

        fileSize.ShouldBe(550);
    }
    
    [Fact]
    public void Can_Calculate_Individual_Sizes()
    {
        var fileSystem = new VirtualFileSystem();
        var dir = fileSystem.Root.AddDirectory("Test");
        dir.AddFile("File1", 100);
        dir.AddFile("File2", 150);
        var subdir = dir.AddDirectory("Subdir");
        subdir.AddFile("File3", 300);
        var dir2 = fileSystem.Root.AddDirectory("Test2");
        dir2.AddFile("File4", 2000);

        var testFileSize = dir.CalculateTotalSize();
        var subdirFileSize = subdir.CalculateTotalSize();

        testFileSize.ShouldBe(550);
        subdirFileSize.ShouldBe(300);        
    }

    [Fact]
    public void Directories_Have_No_Size()
    {
        var fileSystem = new VirtualFileSystem();
        fileSystem.Root.AddDirectory("Test").AddDirectory("Subdir");

        var fileSize = fileSystem.Root.CalculateTotalSize();

        fileSize.ShouldBe(0);
    }
    
    [Fact]
    public void Can_Go_Up_A_Directory()
    {
        var fileSystem = new VirtualFileSystem();
        fileSystem.Root.AddDirectory("Test").AddDirectory("Subdir");

        fileSystem.CD("Test");
        fileSystem.CD("Subdir");

        fileSystem.Cwd.Name.ShouldBe("Subdir");
        fileSystem.UpDirectory();

        fileSystem.Cwd.Name.ShouldBe("Test");
    }

    [Fact]
    public void Can_Calculate_Free_Disk_Space()
    {
        var fileSystem = new VirtualFileSystem(1000);
        var dir = fileSystem.Root.AddDirectory("Test");
        dir.AddFile("File1", 100);
        dir.AddFile("File2", 150);

        int freeDiskSpace = fileSystem.CalculateFreeDiskSpace();

        freeDiskSpace.ShouldBe(750);
    }

}