using AdventOfCode2021.Helpers.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Day6
    {
        public static long Process(int days) 
        {
            List<int> input = FileUtil.GetFile("Input\\Day6.txt")[0].Split(',').Select(int.Parse).ToList();

            long[] dayArr = new long[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            long totalFish = 0;

            foreach (int day in input)
            {
                dayArr[day]++;
                totalFish++;
            }

            for (int i = 0; i < days; i++)
            {
                long newFish = dayArr[0];
                totalFish += newFish;

                dayArr[0] = dayArr[1];
                dayArr[1] = dayArr[2];
                dayArr[2] = dayArr[3];
                dayArr[3] = dayArr[4];
                dayArr[4] = dayArr[5];
                dayArr[5] = dayArr[6];
                dayArr[6] = dayArr[7] + newFish;
                dayArr[7] = dayArr[8];
                dayArr[8] = newFish;
            }


            return totalFish;
        }
    }
}
