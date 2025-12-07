public abstract class Day {
    public string ClassName => GetType().Name;

    public int Number => Utils.GrabInt(ClassName);

    public int Part { get; set; }

    public bool IsPart1 => Part == 1;

    public bool UseSample { get; set; } = false;

    private string RealOrSample => UseSample ? "sample" : "real";
    private string FileDirectory => UseSample ? "Samples" : "Inputs";


    public void Submit(string answer) {
        if (string.IsNullOrEmpty(answer))
            throw new ArgumentException("No answer was given. ");
        Output = answer;
    }

    public string? Output {
        get => field;
        set {
            field = value;
            Console.WriteLine($"Answer for Day {Number} was :: {field}");
        }
    }

    public List<string> Lines => GetLines();

    public List<string> GetLines() {
        string path = Path.Combine("Files", FileDirectory, $"{ClassName}.txt");
        if (!File.Exists(path))
            throw new FileNotFoundException($"⚠️ '{path}' not found!");

        return File.ReadAllLines(path).ToList();
    }

    public abstract void Part1();
    public abstract void Part2();

    public Action Method => Part switch {
        1 => Part1,
        2 => Part2,
        _ => throw new ArgumentException("⚠️ You must set a Part!"),
    };

    public void Run() {
        Console.WriteLine($"Running Day {Number}");
        Console.WriteLine($"Running Part {Part} with {RealOrSample} data");
        Method.Invoke();
    }
}