namespace aoc2025.Days;

public sealed class Day03 : Day {

    public List<List<int>> Banks => Lines
        .Select(bank => bank
            .Select(battery => int.Parse(battery.ToString()))
            .ToList())
        .ToList();

    public List<int> GetCandidates(int bankIndex) {
        var bank = Banks.ElementAt(bankIndex);

        if (LowIndex == -1) {
            return bank.Slice(0, bank.Count - 1);
        }

        LowIndex++;
        return bank.Slice(LowIndex, bank.Count - LowIndex);
    }

    public int GetBestRemainingBattery(List<int> candidates) =>
        candidates.Max();

    public int GetBestRemainingBattery(int bankIndex, int battery) =>
        Banks.ElementAt(bankIndex).IndexOf(battery);

    public long TotalJoltage { get; set; }

    public int BatteryCount => IsPart1 ? 2 : 12;

    public int LowIndex { get; set; } = -1;

    public List<long> Joltages { get; set; } = new();

    public long NextJoltage(int bankIndex = 0) {
        if (bankIndex >= Banks.Count)
            return TotalJoltage = Joltages.Sum();

        long joltage = 0;
        LowIndex = -1;

        for (int i = BatteryCount; i > 0; i--) {
            var candidates = GetCandidates(bankIndex);

            if (!candidates.Any())
                break;

            var battery = GetBestRemainingBattery(candidates);
            var batteryIndex = GetBestRemainingBattery(bankIndex, battery);

            LowIndex = batteryIndex;

            joltage += (long)Math.Pow(10, i - 1) * battery;
        }

        Joltages.Add(joltage);

        return NextJoltage(bankIndex + 1);
    }

    public override void Part1() {
        long total = NextJoltage();
        Submit($"{total}");
    }

    public override void Part2() {
        long total = NextJoltage();
        Submit($"{total}");
    }

}