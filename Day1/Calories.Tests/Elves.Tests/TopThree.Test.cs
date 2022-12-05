namespace Calories.Tests.Elves.Tests;

public class TopThreeTests
{
    [Fact]
    public void TopThreeElves_Returns_TopThree() 
    {
        var manager = new Calories.Elves.ElfManager();        
        manager.ParseData(new string[] { "251", "", 
                                         "521", "5", "", 
                                         "52", "",
                                         "108", "",
                                         "500", ""});

        var topThreeElves = manager.GetTopThreeElves();

        topThreeElves.Count().ShouldBe(3);
    }

    [Fact]
    public void TopThreeElves_Returns_TopTwo_If_Not_Enough_Data() 
    {
        var manager = new Calories.Elves.ElfManager();        
        manager.ParseData(new string[] { "251", "", 
                                         "521", "5" });

        var topThreeElves = manager.GetTopThreeElves();

        topThreeElves.Count().ShouldBe(2);
    }

    
    [Fact]
    public void TopThreeElves_Returns_Empty_With_No_Data() 
    {
        var manager = new Calories.Elves.ElfManager();

        var topThreeElves = manager.GetTopThreeElves();

        topThreeElves.Count().ShouldBe(0);
    }

    [Fact]
    public void TopThreeElves_Returns_Elves_In_Descending_Order_Of_Calories() 
    {
        var manager = new Calories.Elves.ElfManager();        
        manager.ParseData(new string[] { "251", "", 
                                         "521", "5", "", 
                                         "52", "",
                                         "108", "",
                                         "500", ""});

        var topThreeElves = manager.GetTopThreeElves();

        topThreeElves.First().CalculateTotalCalories().ShouldBe(526);
        topThreeElves.ElementAt(1).CalculateTotalCalories().ShouldBe(500);
        topThreeElves.ElementAt(2).CalculateTotalCalories().ShouldBe(251);
    }
}