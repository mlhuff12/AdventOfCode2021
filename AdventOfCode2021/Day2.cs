namespace AdventOfCode2021
{
    internal class Day2
    {
        public static int ProcessPart1()
        {
            string[] input = File.ReadLines("Input\\Day2.txt").ToArray();

            int x = 0;
            int y = 0;

            foreach (string line in input)
            {
                string[] lineArr = line.Split(' ');

                if (lineArr.Length == 2)
                {
                    string direction = lineArr[0];
                    int number = Convert.ToInt32(lineArr[1]);

                    switch (direction.ToLower())
                    {
                        case "forward":
                            y += number;
                            break;
                        case "down":
                            x += number;
                            break;
                        case "up":
                            x -= number;
                            break;
                    }
                }
            }

            return x * y;
        }

        public static int ProcessPart2()
        {
            string[] input = File.ReadLines("Input\\Day2.txt").ToArray();

            int x = 0;
            int y = 0;
            int aim = 0;

            foreach (string line in input)
            {
                string[] lineArr = line.Split(' ');

                if (lineArr.Length == 2)
                {
                    string direction = lineArr[0];
                    int number = Convert.ToInt32(lineArr[1]);

                    switch (direction.ToLower())
                    {
                        case "forward":
                            y += aim * number;
                            x += number;
                            break;
                        case "down":
                            aim += number;
                            break;
                        case "up":
                            aim -= number;
                            break;
                    }
                }
            }

            return x * y;
        }
    }
}
