namespace AdventOfCode2024
{
    internal class Day6 : IDay
    {
        private char[,] ReadMap(string[] input, out int posX, out int posY)
        {
            var map = new char[input.Length, input.Length];

            posX = 0;
            posY = 0;

            for (int x = 0; x < input.Length; x++)
            {
                for (int y = 0; y < input.Length; y++)
                {
                    map[x, y] = input[x][y];

                    if (input[x][y] == '^')
                    {
                        posX = x;
                        posY = y;
                    }
                }
            }

            return map;
        }

        private void WriteMap(char[,] map)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    Console.Write(map[x, y]);
                }

                Console.WriteLine();
            }
        }
        
        private (int, int) GetForwardVector(int direction)
        {
            return (direction % 4) switch
            {
                0 => (-1,  0),
                1 => ( 0,  1),
                2 => ( 1,  0),
                3 => ( 0, -1),
            };
        }

        private bool IsOutOfBounds(char[,] map, int x, int y)
        {
            return x < 0 || y < 0 || x >= map.GetLength(0) || y >= map.GetLength(0);
        }

        public object Part1(string[] input)
        {
            var map = ReadMap(input, out var x, out var y);
            int direction = 0, positions = 1;

            while (true)
            {
                // We walkin
                var forward = GetForwardVector(direction);

                if (map[x, y] != '^') positions++;
                map[x, y] = '^';

                if (IsOutOfBounds(map, x + forward.Item1, y + forward.Item2))
                {
                    break;
                }

                // Check for an obstable
                var obstacle = map[x + forward.Item1, y + forward.Item2];

                if (obstacle == '#')
                {
                    direction += 1;
                    continue;
                }

                // Go forward
                x += forward.Item1;
                y += forward.Item2;
            }

            return positions;
        }

        public object Part2(string[] input)
        {
            return 0;
        }
    }
}
