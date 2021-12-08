using AdventOfCode2021.Helpers.cs;

namespace AdventOfCode2021
{
    internal class Day7
    {
        public static long Process(int part)
        {
            //List<int> input = FileUtil.GetFile("Input\\Day7Sample.txt")[0].Split(',').Select(int.Parse).ToList();
            List<int> input = FileUtil.GetFile("Input\\Day7.txt")[0].Split(',').Select(int.Parse).ToList();

            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int crab in input)
            {
                if (dict.ContainsKey(crab))
                {
                    dict[crab]++;
                }
                else
                {
                    dict[crab] = 1;
                }
            }

            return CalculateAlignmentFuel(part, input.Min(), input.Max(), dict);
        }

        private static long CalculateAlignmentFuel(int part, int minLocation, int maxLocation, Dictionary<int, int> dict)
        {
            long lowestFuel = long.MaxValue;

            for(int loc = minLocation; loc <= maxLocation; loc++)
            {
                long tempFuel = 0;
                foreach (KeyValuePair<int, int> kv in dict)
                {
                    if (kv.Key != loc)
                    {
                        if (part == 1)
                        {
                            tempFuel += Math.Abs(loc - kv.Key) * kv.Value;
                        }
                        else
                        {
                            int moves = Math.Abs(loc - kv.Key);
                            int singleFuel = 0; 

                            for (int i = 1; i <= moves; i++)
                            {
                                singleFuel += i;
                            }
                            tempFuel += singleFuel * kv.Value;
                        }
                    }
                }

                if (lowestFuel > tempFuel)
                {
                    lowestFuel = tempFuel;
                }
            }
            return lowestFuel;
        }
    }
}
