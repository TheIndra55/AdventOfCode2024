using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
    internal class Day3 : IDay
    {
        public object Part1(string[] input)
        {
            var memory = string.Join("", input);
            var matches = new Regex(@"mul\((\d+),(\d+)\)").Matches(memory);

            var sum = matches.Sum(x => int.Parse(x.Groups[1].Value) * int.Parse(x.Groups[2].Value));

            return sum;
        }

        public object Part2(string[] input)
        {
            var memory = string.Join("", input);
            var matches = new Regex(@"(mul|do|don't)\(((\d+),(\d+))?\)").Matches(memory);

            var sum = 0;
            var enabled = true;

            foreach (Match match in matches)
            {
                var instruction = match.Groups[1].Value;

                if (instruction == "do") enabled = true;
                if (instruction == "don't") enabled = false;

                if (instruction == "mul" && enabled) sum += int.Parse(match.Groups[3].Value) * int.Parse(match.Groups[4].Value);
            }

            return sum;
        }
    }
}
