namespace AdventOfCode2024
{
    internal class Day1 : IDay
    {
        public object Part1(string[] input)
        {
            var locations = input.Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries));

            var group1 = locations.Select(x => int.Parse(x[0])).OrderBy(x => x).ToList();
            var group2 = locations.Select(x => int.Parse(x[1])).OrderBy(x => x).ToList();

            var distance = group1.Select((x, i) => Math.Max(x, group2[i]) - Math.Min(x, group2[i])).Sum();

            return distance;
        }

        public object Part2(string[] input)
        {
            var locations = input.Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries));

            var group1 = locations.Select(x => int.Parse(x[0])).ToList();
            var group2 = locations.Select(x => int.Parse(x[1])).ToList();

            var score = group1.Select(x => x * group2.Count(y => y == x)).Sum();

            return score;
        }
    }
}
