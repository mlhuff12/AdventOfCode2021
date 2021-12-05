using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode2021.Helpers.cs
{
    internal class FileUtil
    {
        //path like "Input\\Day4Sample.txt"
        public static List<string> GetFile(string path)
        {
            return File.ReadLines(path).ToList();
        }
    }
}