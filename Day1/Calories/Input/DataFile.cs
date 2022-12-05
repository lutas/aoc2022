namespace Calories.Input;

public class DataFile : IData
{
    private List<string> _data = new List<string>();
    private bool _hasData = false;
    public DataFile()
    {
    }

    public bool Load(string filePath)
    {
        _data.Clear();

        try 
        {
            var lines = System.IO.File.ReadAllLines(filePath);
            _data.AddRange(lines);
            return true;
        }
        catch (System.IO.IOException ex)
        {
            Console.Error.WriteLine(ex.Message);
            return false;
        }
    }

    public IEnumerable<string> Data => _data;

    public bool HasData => _hasData;
}