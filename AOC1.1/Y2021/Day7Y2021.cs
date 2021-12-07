using System;
using System.Linq;

namespace AOC1._1.Y2021
{
    public class Day7Y2021
    {
        public static void Task1()
        {
            var lines = System.IO.File.ReadAllLines(@"C:\Coding\AdventOfCode\AOC1.1\Y2021\Data7.txt");
            var crabbies = lines[0].Split(',').Select(int.Parse).ToList();

            var crabbiesMin = crabbies.Min();
            var crabbiesMax = crabbies.Max();

            var minSum = int.MaxValue;
            for (int i = crabbiesMin; i < crabbiesMax; i++)
            {
                minSum = Math.Min(crabbies.Sum(mrCrab => Math.Abs(mrCrab - i)), minSum);
            }

            Console.WriteLine($"Day 7, task 1: {minSum}");
        }

        public static void Task2()
        {
            var lines = System.IO.File.ReadAllLines(@"C:\Coding\AdventOfCode\AOC1.1\Y2021\Data7.txt");
            var crabbies = lines[0].Split(',').Select(int.Parse).ToList();

            var crabbiesMin = crabbies.Min();
            var crabbiesMax = crabbies.Max();

            var minSum = int.MaxValue;
            for (int i = crabbiesMin; i < crabbiesMax; i++)
            {
                minSum = Math.Min(crabbies.Sum(mrCrab => Sums(Math.Abs(mrCrab - i))), minSum);
            }

            Console.WriteLine($"Day 7, task 2: {minSum}");
        }

        private static int Sums(int n)
        {
            return n * (n + 1) / 2;
        }
    }
}