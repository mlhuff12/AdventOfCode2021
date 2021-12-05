using AdventOfCode2021.Helpers.cs;

namespace AdventOfCode2021
{
    internal class Day5
    {
        public static int Process(int part)
        {
            List<string> input = FileUtil.GetFile("Input\\Day5.txt");
            List<List<string>> processedInput = new List<List<string>>();

            foreach (string line in input)
            {
                processedInput.Add(line.Split(" -> ").ToList());
            }

            Dictionary<string, int> coords = MapCoordinates(part, processedInput);
            //PrintCoordinates(coords);
            return coords.Values.Count(x => x > 1);
        }

        private static Dictionary<string, int> MapCoordinates(int part, List<List<string>> coordinates)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            // Do I need segment class?
            foreach (List<string> segmentCoord in coordinates)
            {
                int x1, x2, y1, y2;
                int[] begin = segmentCoord[0].Split(',').Select(int.Parse).ToArray();
                int[] end = segmentCoord[1].Split(',').Select(int.Parse).ToArray();

                x1 = begin[0];
                y1 = begin[1];
                x2 = end[0];
                y2 = end[1];

                if (x1 == x2)
                {
                    // Vertical Line
                    AddCoordinateToDictionary(dict, segmentCoord[0]);
                    AddCoordinateToDictionary(dict, segmentCoord[1]);

                    int yTemp = y1 < y2 ? y1 : y2;
                    int yEnd = y1 > y2 ? y1 : y2;
                    yTemp++;
                    while (yTemp != yEnd)
                    {
                        AddCoordinateToDictionary(dict, string.Format("{0},{1}", x1, yTemp));
                        yTemp++;
                    }
                }
                else if (y1 == y2)
                {
                    // Horizontal Line
                    AddCoordinateToDictionary(dict, segmentCoord[0]);
                    AddCoordinateToDictionary(dict, segmentCoord[1]);

                    int xTemp = x1 < x2 ? x1 : x2;
                    int xEnd = x1 > x2 ? x1 : x2;
                    xTemp++;
                    while (xTemp != xEnd)
                    {
                        AddCoordinateToDictionary(dict, string.Format("{0},{1}", xTemp, y1));
                        xTemp++;
                    }
                }
                else if (part == 2)
                {
                    // Diagonal
                    // if x1 < x2 increase
                    // if x1 > x2 decrease
                    // if y1 < y2 increase
                    // if y1 > y2 decrease

                    AddCoordinateToDictionary(dict, segmentCoord[0]);
                    AddCoordinateToDictionary(dict, segmentCoord[1]);

                    int xTemp = x1 < x2 ? (x1 + 1) : (x1 - 1);
                    int yTemp = y1 < y2 ? (y1 + 1) : (y1 - 1);

                    while (xTemp != x2 && yTemp != y2)
                    {
                        AddCoordinateToDictionary(dict, string.Format("{0},{1}", xTemp, yTemp));
                        xTemp = x1 < x2 ? (xTemp + 1) : (xTemp - 1);
                        yTemp = y1 < y2 ? (yTemp + 1) : (yTemp - 1);
                    }

                }
            }
            return dict;
        }

        private static void AddCoordinateToDictionary(Dictionary<string, int> dict, string coord)
        {
            if (dict.ContainsKey(coord))
            {
                dict[coord]++;
            }
            else
            {
                dict.Add(coord, 1);
            }
        }

        private static void PrintCoordinates(Dictionary<string, int> dict)
        {
            foreach (KeyValuePair<string, int> kv in dict)
            {
                Console.WriteLine(String.Format("({0}) : Times = {1}", kv.Key, kv.Value));
            }
        }
    }
}
