namespace aoc2025.Days;

public sealed class Day01 : Day
{
    struct Action
    {
        public int Mult { get; set; }
        public int Amount { get; set; }
    }

    public int Count { get; private set; }
    public int Current { get; private set; } = 50;

    public override void Run()
    {
        base.Run();

        var actions = Lines.Select(row =>
            new Action
            {
                Mult = Utils.GrabAlpha(row) == "R" ? 1 : -1,
                Amount = Utils.GrabInt(row),
            });

        foreach (var row in actions)
        {
            Current += row.Amount * row.Mult;
            Current %= 100;

            if (Current == 0)
                Count++;
        }

        Output = $"{Count}";
    }
}