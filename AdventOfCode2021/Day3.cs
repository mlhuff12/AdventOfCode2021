using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Day3
    {
        public static long ProcessPart1()
        {
            string[] input = File.ReadLines("Input\\Day3.txt").ToArray();
            string[] colArr = new string[input[0].Length];

            string gammaString = string.Empty;
            string epsilonString = string.Empty;

            for (int i = 0; i < colArr.Length; i++)
            {
                foreach (string line in input)
                {
                    colArr[i] = colArr[i] == null ? line.Substring(i, 1) : colArr[i] + line.Substring(i, 1);
                }

                int zeros = colArr[i].Count(x => x == '0');
                int ones = colArr[i].Count(x => x == '1');

                gammaString += zeros > ones ? "0" : "1";
                epsilonString += zeros > ones ? "1" : "0";
            }

            return Convert.ToInt32(gammaString, 2) * Convert.ToInt32(epsilonString, 2);
        }

        public static long ProcessPart2()
        {
            string[] input = File.ReadLines("Input\\Day3.txt").ToArray();
            string oxygenRating = GetOxygenRating(input);
            string co2Rating = GetC02Rating(input);

            return Convert.ToInt32(oxygenRating, 2) * Convert.ToInt32(co2Rating, 2); ;
        }

        private static string GetOxygenRating(string[] input)
        {
            string[] newInput = input;

            for (int i = 0; i < input.Length; i++)
            {
                if (newInput.Length > 1)
                { 
                    newInput = GetInputWithOxygenBitCriteriaApplied(i, newInput);
                }
            }
            return newInput[0];
        }

        private static string GetC02Rating(string[] input)
        {
            string[] newInput = input;

            for (int i = 0; i < input.Length; i++)
            {
                if (newInput.Length > 1)
                {
                    newInput = GetInputWithCO2BitCriteriaApplied(i, newInput);
                }
            }
            return newInput[0];
        }

        private static string[] GetColArray(string[] input)
        {
            string[] colArr = new string[input[0].Length];
            for (int i = 0; i < colArr.Length; i++)
            {
                foreach (string line in input)
                {
                    colArr[i] = colArr[i] == null ? line.Substring(i, 1) : colArr[i] + line.Substring(i, 1);
                }
            }
            return colArr;
        }

        private static string[] GetInputWithOxygenBitCriteriaApplied(int indx, string[] input)
        {
            string[] colArr = GetColArray(input);
            int zeros = colArr[indx].Count(x => x == '0');
            int ones = colArr[indx].Count(x => x == '1');
            int bitCriteria = zeros == ones ? 1 : (zeros > ones ? 0 : 1);
            string bcString = bitCriteria.ToString();

            List<string> newInput = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Substring(indx, 1) == bcString)
                {
                    newInput.Add(input[i]);
                }
            }

            return newInput.ToArray();
        }

        private static string[] GetInputWithCO2BitCriteriaApplied(int indx, string[] input)
        {
            string[] colArr = GetColArray(input);

            int zeros = colArr[indx].Count(x => x == '0');
            int ones = colArr[indx].Count(x => x == '1');
            int bitCriteria = zeros == ones ? 0 : (zeros > ones ? 1 : 0);
            string bcString = bitCriteria.ToString();

            List<string> newInput = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Substring(indx, 1) == bcString)
                {
                    newInput.Add(input[i]);
                }
            }

            return newInput.ToArray();
        }
    }
}
