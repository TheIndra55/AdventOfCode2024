namespace AdventOfCode2024
{
    internal class Day4 : IDay
    {
        public char[,] GetGrid(string[] lines)
        {
            var grid = new char[lines.Length, lines[0].Length];

            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];

                for (int j = 0; j < line.Length; j++)
                {
                    grid[i, j] = line[j];
                }
            }

            return grid;
        }

        public bool CheckMatch(ref char[] found)
        {
            var match = new string(found) == "XMAS" || new string(found) == "SMAX";

            Array.Clear(found);

            return match;
        }

        public int CheckMatches(char[,] grid, int x, int y)
        {
            var matches = 0;
            var found = new char[4];

            // right
            if (y + 3 < grid.GetLength(1))
            {
                for (int i = 0; i < 4; i++)
                {
                    found[i] = grid[x, y + i];
                }
            }

            if (CheckMatch(ref found)) matches++;

            // left
            if (y - 3 >= 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    found[i] = grid[x, y - i];
                }
            }

            if (CheckMatch(ref found)) matches++;

            // down
            if (x + 3 < grid.GetLength(0))
            {
                for (int i = 0; i < 4; i++)
                {
                    found[i] = grid[x + i, y];
                }
            }

            if (CheckMatch(ref found)) matches++;

            // up
            if (x - 3 >= 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    found[i] = grid[x - i, y];
                }
            }

            if (CheckMatch(ref found)) matches++;

            // right up
            if (y + 3 < grid.GetLength(1) && x - 3 >= 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    found[i] = grid[x - i, y + i];
                }
            }

            if (CheckMatch(ref found)) matches++;

            // left up
            if (y - 3 >= 0 && x - 3 >= 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    found[i] = grid[x - i, y - i];
                }
            }

            if (CheckMatch(ref found)) matches++;

            // right down
            if (x + 3 < grid.GetLength(0) && y + 3 < grid.GetLength(1))
            {
                for (int i = 0; i < 4; i++)
                {
                    found[i] = grid[x + i, y + i];
                }
            }

            if (CheckMatch(ref found)) matches++;

            // left down
            if (x + 3 < grid.GetLength(0) && y - 3 >= 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    found[i] = grid[x + i, y - i];
                }
            }

            if (CheckMatch(ref found)) matches++;

            return matches;
        }

        public bool CheckMatches2(char[,] grid, int x, int y)
        {
            if (x > 0 && y > 0 && x + 1 < grid.GetLength(0) && y + 1 < grid.GetLength(1))
            {
                var found = new char[]
                {
                    grid[x - 1, y - 1],
                    grid[x - 1, y + 1],
                    grid[x + 1, y - 1],
                    grid[x + 1, y + 1],
                };

                var match = new string(found);

                return match == "MSMS" || match == "MMSS" || match == "SSMM" || match == "SMSM";
            }

            return false;
        }

        public object Part1(string[] input)
        {
            var grid = GetGrid(input);
            var matches = 0;

            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    if (grid[x, y] == 'X')
                    {
                        matches += CheckMatches(grid, x, y);
                    }
                }
            }

            return matches;
        }

        public object Part2(string[] input)
        {
            var grid = GetGrid(input);
            var matches = 0;

            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    if (grid[x, y] == 'A')
                    {
                        if (CheckMatches2(grid, x, y)) matches++;
                    }
                }
            }

            return matches;
        }
    }
}
