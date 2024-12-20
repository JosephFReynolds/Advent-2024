using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_2024
{
    public static class FileReader
    {
        /// <summary>
        /// Read the input data from file and return an array of strings
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] ReadFile(string path)
        {
            try
            {
                string[] lines = File.ReadAllLines(path);
                return lines;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
