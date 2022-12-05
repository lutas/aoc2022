namespace Calories.Elves;

public class ElfManager
{
    private readonly List<Elf> elves;

    public ElfManager()
    {
        elves = new List<Elf>();
    }

    public int ElfCount => elves.Count;

    public Elf? GetElf(int index)
    {
        if (index < 0 || index >= elves.Count) 
        {
            return null;
        }

        return elves[index];
    }
    
    public int ParseData(IEnumerable<string> lineData)
    {
        var elves = new List<Elf>();
        var current = new Elf();
        bool elfHasData = false;
        foreach (string line in lineData) 
        {
            if (line.Trim().Length == 0)
            {
                if (elfHasData) 
                {
                    elves.Add(current);
                    elfHasData = false;
                    current = new Elf();
                }
            }
            else 
            {
                int calories;
                if (int.TryParse(line, out calories))
                {
                    current.AddCalories(calories);
                }
                elfHasData = true;
            }
        }  

        if (elfHasData) 
        {
            elves.Add(current);
        }

        this.elves.AddRange(elves);

        return elves.Count;
    }

    public Elf? GetElfWithMostCalories()
    {
        if (elves.Count == 0) 
        {
            return null;
        }

        var highest = elves.Aggregate((elf1, elf2) => {
            return elf1.CalculateTotalCalories() > elf2.CalculateTotalCalories() ? elf1 : elf2;
        });

        return highest;
    }

    public IEnumerable<Elf> GetTopThreeElves()
    {
        var elves = this.elves.OrderByDescending(elf => elf.CalculateTotalCalories());
        return elves.Take(3);
    }
}