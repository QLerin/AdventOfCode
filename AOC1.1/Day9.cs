using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC1._1
{
    public class Day9
    {
        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data9.txt");
            var numbers = lines.Select(line => long.Parse(line)).ToList();
            var preamble = 25;

            for (int i = preamble; i < numbers.Count; i++)
            {
                var sums = new HashSet<long>();
                for (var first = i - preamble; first < i + preamble - 1; first++)
                {
                    for (var second = i - preamble + 1; second < i + preamble; second++)
                    {
                        if (first == second)
                        {
                            continue;
                        }

                        sums.Add(numbers[first] + numbers[second]);
                    }
                }
                if (!sums.Contains(numbers[i]))
                {
                    Console.WriteLine($"Day 9, task 1: {numbers[i]}");
                    break;
                }
            }
        }

        public static void Task2()
        {
        }
    }
}