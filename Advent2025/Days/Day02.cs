using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace aoc2025.Days;

public sealed class Day02 : Day {
    public class IdSequence {
        public string Id;
    }

    private IdSequence IdSequenceFactory(string line) {
        var bds = line
            .Split('-')
            .Select(int.Parse)
            .ToImmutableArray();

        (int Start, int End) bounds = (bds[0], bds[1]);

        var idSeq = new IdSequence();

        for (int i = bounds.Start; i <= bounds.End; i++) {
            idSeq.Id += i;
        }

        return idSeq;
    }

    private IEnumerable<string> Pairs =>
        Lines.SelectMany(row => row.Split(','));

    private IEnumerable<IdSequence> IdSequences =>
        Pairs.Select(IdSequenceFactory);


    private class MaxMunch {
        private int Position { get; set; }

        public string? Current { get; set; } = string.Empty;

        public bool IsMunching => Current is not null;

        public required string Source { get; set; }

        public required Func<string, Match> MunchMatch { get; set; }

        public string? Run(bool clearCurrent = false) {
            if (clearCurrent)
                Current = string.Empty;

            var nc = Source
                .ElementAtOrDefault(Position);

            var nextChar = nc == default ? null : nc.ToString();
            Position++;

            if (nextChar is null || Current == "0") {
                Current = null;
                return Current;
            }

            var next = Current + nextChar;
            var match = MunchMatch.Invoke(next);
            if (match.Success) {
                Current = next;
                return Run();
            }

            return Current;
        }
    }

    public List<int> InvalidIds { get; set; } = new();

    public override void Part1() {
        foreach (var seq in IdSequences) {
            var munch = new MaxMunch {
                Source = seq.Id,
                MunchMatch = (string current) =>
                    Regex.Match(seq.Id, @$"(?>(?:{Regex.Escape(current)})){{2}}"),
            };

            while (true) {
                munch.Run(clearCurrent: true);

                if (munch.Current is null)
                    break;

                if (munch.Current.Length > 1)
                    InvalidIds.Add(int.Parse(munch.Current));
            }
        }

        Output = $"{InvalidIds.Sum()}";
    }

    public override void Part2() {

    }

}