using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Day_01
{
    public static class FileReader
    {
        public static (int[], int[]) GetArrays(string path)
        {
            //Get the text from the file
            string[] inputList = ReadFile(path);

            //Parse the single array of strings a tuple of two arrays of int
            var tuple = ParseArrays(inputList);

            //sort the arrays

            Array.Sort(tuple.Item1);
            Array.Sort(tuple.Item2);

            return tuple;
        }


        /// <summary>
        /// Parse a single array of strings into two arrays of integers
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        private static (int[], int[]) ParseArrays(string[] inputArray)
        {
            //build arrays to hold the data
            int arrayLength = inputArray.Count();

            int[] array1 = new int[arrayLength];
            int[] array2 = new int[arrayLength];

            //iterate through the array of strings
            for (int i = 0; i < arrayLength; i++)
            {
                string line = inputArray[i];

                //split the line into 2 strings
                string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                //if we failed to get 2 strings from the split, skip this line
                if(parts.Length != 2 ) { continue; }

                //parse the 2 strings into integers and populate the two arrays
                if (int.TryParse(parts[0], out int num1) && int.TryParse(parts[1], out int num2))
                {
                    array1[i] = num1;
                    array2[i] = num2;
                }
            }

            return (array1, array2);
        }


        /// <summary>
        /// Read the input data from file and return an array of strings
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static string[] ReadFile(string path)
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
