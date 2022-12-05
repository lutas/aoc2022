namespace Calories.Elves;

public class Elf 
{
    private readonly List<int> _calorieValues;

    public Elf()
    {   
        _calorieValues = new List<int>();     
    }

    public void AddCalories(int value)
    {
        _calorieValues.Add(value);
    }

    public int CalculateTotalCalories()
    {
        return _calorieValues.Sum();
    }
}