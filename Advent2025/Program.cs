using System;
using aoc2025.Days;

namespace AoC2025;

class Program
{
    public static int DayNumber => 1;

    public static Day Day => DayNumber switch
    {
        1 => new Day01(),
        _ => throw new ArgumentOutOfRangeException(nameof(DayNumber))
    };

    static void Main()
    {
        Day.Run();
    }
}