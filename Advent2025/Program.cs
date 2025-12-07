using aoc2025.Days;

namespace AoC2025;

class Program {
    public static int DayNumber => 3;
    public static int PartNumber => 2;
    public static bool UseSample => true;

    public static Day Day => DayNumber switch {
        1 => new Day01 { Part = PartNumber, UseSample = UseSample, },
        2 => new Day02 { Part = PartNumber, UseSample = UseSample, },
        3 => new Day03 { Part = PartNumber, UseSample = UseSample, },
        _ => throw new ArgumentOutOfRangeException(nameof(DayNumber))
    };

    static void Main() {
        Day.Run();
    }
}