using System.ComponentModel;
using System.Text.RegularExpressions;
public abstract class Day
{
    public string ClassName => GetType().Name;
    public int Number => Utils.GrabInt(ClassName);

    public string? Output
    {
        get => field;
        set
        {
            field = value;
            Console.WriteLine($"Answer for Day {Number} was :: {field}");
        }
    }

    public List<string> Lines => GetLines();

    public List<string> GetLines()
    {
        string path = Path.Combine("./Files", $"{ClassName}.txt");
        if (!File.Exists(path))
            throw new FileNotFoundException($"⚠️ '{path}' not found!");

        return File.ReadAllLines(path).ToList();
    }

    public virtual void Run()
    {
        Console.WriteLine($"Running Day {Number}");
    }
}