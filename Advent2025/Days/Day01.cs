namespace aoc2025.Days;

public sealed class Day01 : Day
{
    public struct Action
    {
        public int Mult { get; set; }
        public int Amount { get; set; }
    }

    public IEnumerable<Action> Actions => Lines
        .Select(row =>
                new Action
                {
                    Mult = Utils.GrabAlpha(row) == "R" ? 1 : -1,
                    Amount = Utils.GrabInt(row),
                });


    public int Count { get; private set; }
    public int Current { get; private set; } = 50;

    public override void Part1()
    {
        foreach (var row in Actions)
        {
            Current += row.Amount * row.Mult;
            Current %= 100;

            if (Current == 0)
                Count++;
        }

        Output = $"{Count}";
    }

    public override void Part2()
    {
        foreach (var row in Actions)
        {
            var absNext = row.Amount + Math.Abs(Current);
            if (absNext >= 100)
                Count += absNext / 100;

            var next = row.Amount * row.Mult;

            if (next == 0)
                Count++;

            Current += next;
            Current %= 100;
        }

        Output = $"{Count}";
    }

}