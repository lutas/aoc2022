// See https://aka.ms/new-console-template for more information
{
    int highestSingleElfCalories = Main.CalculateMostCaloriesForASingleElf("elf-calories.txt");

    if (highestSingleElfCalories < 0) 
    {
        Console.Error.WriteLine("Highest single: Failed to calculate elf calories");
    }
    else 
    {
        Console.WriteLine("Highest single: Calorie count is {0}", highestSingleElfCalories);
    }
}

{
    int topThreeCalories = Main.CalculateTopThreeCalories("elf-calories.txt");
    if (topThreeCalories < 0) 
    {
        Console.Error.WriteLine("Top Three: Failed to calculate elf calories for top three");
    }
    else 
    {
        Console.WriteLine("Top Three: Calorie count is {0}", topThreeCalories);
    }
}