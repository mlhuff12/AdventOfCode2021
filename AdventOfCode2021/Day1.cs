namespace AdventOfCode2021
{
    internal class Day1
    {
        public static int Process(int numberToCombine)
        {
            int[] input = File.ReadLines("Input\\Day1.txt")
                       .Select(x => int.Parse(x))
                       .ToArray();

            int lastMeasurement = int.MaxValue;
            int totalIncreases = 0;

            for (int i = numberToCombine - 1; i < input.Length; i++)
            {
                int measurement = input[i];
                for (int j = 1; j < numberToCombine; j++)
                {
                    measurement += input[i - j];
                }

                if (measurement > lastMeasurement)
                {
                    totalIncreases++;
                }
                lastMeasurement = measurement;
            }
            return totalIncreases;
        }
    }
}
