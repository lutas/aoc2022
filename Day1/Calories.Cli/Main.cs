using Calories;

public class Main
{
    public static int CalculateMostCaloriesForASingleElf(string filePath)
    {
        var file = new Calories.Input.DataFile();
        if (!file.Load(filePath))
        {
            Console.Error.WriteLine("Failed to load data file");
            return -1;
        }
        
        var elfManager = new Calories.Elves.ElfManager();
        elfManager.ParseData(file.Data);

        var elf = elfManager.GetElfWithMostCalories();
        if (elf == null) 
        {
            Console.Error.WriteLine("No elves found");
            return -1;
        }

        int totalCalories = elf.CalculateTotalCalories();
        return totalCalories;
    }
    public static int CalculateTopThreeCalories(string filePath)
    {
        var file = new Calories.Input.DataFile();
        if (!file.Load(filePath))
        {
            Console.Error.WriteLine("Failed to load data file");
            return -1;
        }
        
        var elfManager = new Calories.Elves.ElfManager();
        elfManager.ParseData(file.Data);

        var elves = elfManager.GetTopThreeElves();
        int totalCalories = elves.Sum(elf => elf.CalculateTotalCalories());
        
        return totalCalories;
    }
}
