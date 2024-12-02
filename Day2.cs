namespace AdventOfCode2024
{
    internal class Day2 : IDay
    {
        public object Part1(string[] input)
        {
            var reports = 0;

            foreach (var report in input)
            {
                var levels = report.Split(" ").Select(int.Parse).ToList();

                var direction = levels[0] > levels[1];
                var safe = true;

                for (int i = 1; i < levels.Count; i++)
                {
                    var increase = Math.Abs(levels[i - 1] - levels[i]);
                    if (increase < 1 || increase > 3) safe = false;

                    if (levels.Take(i).Any(x => (direction && x < levels[i]) || (!direction && x > levels[i]))) safe = false;
                }

                if (safe) reports++;
            }

            return reports;
        }

        public object Part2(string[] input)
        {
            var reports = 0;

            foreach (var report in input)
            {
                var levels = report.Split(" ").Select(int.Parse).ToList();

                var doesFail = (List<int> levels) =>
                {
                    var direction = levels[0] > levels[1];

                    for (int i = 1; i < levels.Count; i++)
                    {
                        var increase = Math.Abs(levels[i - 1] - levels[i]);
                        if (increase < 1 || increase > 3) return true;

                        if (levels.Take(i).Any(x => (direction && x < levels[i]) || (!direction && x > levels[i]))) return true;
                    }

                    return false;
                };

                var fail = doesFail(levels);

                if (fail)
                {
                    // If we fail try again while removing one value
                    for (int i = 0; i < levels.Count; i++)
                    {
                        var levelsWithout = new List<int>(levels);
                        levelsWithout.RemoveAt(i);

                        fail = doesFail(levelsWithout);

                        if (!fail) break;
                    }
                }

                if (!fail) reports++;
            }

            return reports;
        }
    }
}
