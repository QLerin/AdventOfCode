using System;
using System.Collections.Generic;

namespace AOC1._1
{
    public class Day14
    {
        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data14.txt");

            var currentDictionary = new Dictionary<int, string>();
            var currentMask = "";
            foreach (var line in lines)
            {
                if (line.StartsWith("mask"))
                {
                    currentMask = line.Substring(7);
                    continue;
                }

                var key = int.Parse(line.Split(']')[0].Substring(4));
                var value = int.Parse(line.Split(" ")[2]);
                var valueInBinary = Convert.ToString(value, 2);
                var missingZerosCount = 36 - valueInBinary.Length;
                valueInBinary = new string('0', missingZerosCount) + valueInBinary;

                string result = "";
                for (int i = 0; i < currentMask.Length; i++)
                {
                    if (currentMask[i] == 'X')
                    {
                        result += valueInBinary[i];
                        continue;
                    }

                    result += currentMask[i];
                }
                currentDictionary[key] = result;
            }

            ulong sum = GetSum(currentDictionary);

            Console.WriteLine($"Day 14, task 1: {sum}");
        }

        private static ulong GetSum(Dictionary<int, string> currentDictionary)
        {
            ulong sum = 0;
            foreach (var valueKey in currentDictionary)
            {
                sum += Convert.ToUInt64(valueKey.Value, 2);
            }

            return sum;
        }

        public static void Task2()
        {
        }
    }
}