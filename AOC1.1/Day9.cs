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
            long invalidNumber = GetInvalidNumber(numbers);
            Console.WriteLine($"Day 9, task 1: {invalidNumber}");
        }

        public static void Task2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data9.txt");
            var numbers = lines.Select(line => long.Parse(line)).ToList();
            long invalidNumber = GetInvalidNumber(numbers);

            var invalidIndex = numbers.IndexOf(invalidNumber);

            for (var i = 0; i < invalidIndex; i++)
            {
                long sum = 0;
                var sumNumbers = new List<long>();
                for (var j = i; j < invalidIndex; j++)
                {
                    sum += numbers[j];
                    sumNumbers.Add(numbers[j]);
                    if (sum > invalidNumber)
                    {
                        break;
                    }

                    if (invalidNumber == sum)
                    {
                        Console.WriteLine($"Day 9, task 2: {sumNumbers.Min() + sumNumbers.Max()}");
                        return;
                    }
                }
            }
        }

        private static long GetInvalidNumber(List<long> numbers)
        {
            var preamble = 25;
            var invalidNumber = long.MinValue;
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
                    invalidNumber = numbers[i];

                    break;
                }
            }

            return invalidNumber;
        }
    }
}