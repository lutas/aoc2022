namespace Calories.Input;
public interface IData 
{
    bool HasData { get; }
    IEnumerable<string>? Data { get; }
}