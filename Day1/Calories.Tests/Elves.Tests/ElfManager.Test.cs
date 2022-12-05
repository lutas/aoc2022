namespace Calories.Tests.Elves.Tests;

public class ElfManagerTests
{
    [Fact]
    public void Can_Parse_Empty_Data()
    {
        var manager = new Calories.Elves.ElfManager();
        var dataLines = new List<string>();

        int parseCount = manager.ParseData(dataLines);

        parseCount.ShouldBe(0);
    }

    [Fact]
    public void Can_Parse_Single_Elf() 
    {
        var manager = new Calories.Elves.ElfManager();
        var dataLines = new string[] { "251" };

        int parseCount = manager.ParseData(dataLines);

        parseCount.ShouldBe(1);
    }

    [Fact]
    public void Can_Parse_Two_Elves() 
    {
        var manager = new Calories.Elves.ElfManager();
        var dataLines = new string[] { "251", "", "50" };

        int parseCount = manager.ParseData(dataLines);

        parseCount.ShouldBe(2);
    }

    [Fact]
    public void Can_Ignore_Empty_Lines() 
    {
        var manager = new Calories.Elves.ElfManager();
        var dataLines = new string[] { "251", "", "50", "", "" };

        manager.ParseData(dataLines);

        manager.ElfCount.ShouldBe(2);
    }

    [Fact]
    public void Can_Parse_Multiple_Calorie_Values_For_One_Elf() 
    {
        var manager = new Calories.Elves.ElfManager();
        var dataLines = new string[] { "251", "80", "21" };
        manager.ParseData(dataLines);
        var elf = manager.GetElf(0);

        int calorieValue = elf!.CalculateTotalCalories();

        calorieValue.ShouldBe(352);
    }

    [Fact]
    public void GetElvesCount_Matches_A_Single_Parse() 
    {
        var manager = new Calories.Elves.ElfManager();
        var dataLines = new string[] { "251", "80", "21" };
        int numParsedElves = manager.ParseData(dataLines);
        
        numParsedElves.ShouldBe(manager.ElfCount);
    }

    [Fact]
    public void Can_Parse_Multiple_Data() 
    {
        var manager = new Calories.Elves.ElfManager();        
        manager.ParseData(new string[] { "251", "80", "21" });
        manager.ParseData(new string[] { "100", "30" });
        
        manager.ElfCount.ShouldBe(2);
    }    
}