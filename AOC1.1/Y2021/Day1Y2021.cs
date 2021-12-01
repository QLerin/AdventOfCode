using System;
using System.Linq;

namespace AOC1._1.Y2021
{
    public class Day1Y2021
    {
        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Coding\AdventOfCode\AOC1.1\Y2021\Data1.txt");
            var numbers = lines.Select(int.Parse).ToList();

            var count = 0;
            for (var i = 1; i < numbers.Count; i++)
            {
                if (numbers[i - 1] < numbers[i])
                {
                    count++;
                }
            }

            Console.WriteLine($"Day 1, task 1: {count}");
        }

        public static void Task2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Coding\AdventOfCode\AOC1.1\Y2021\Data1.txt");
            var numbers = lines.Select(int.Parse).ToList();

            var count = 0;
            for (var i = 3; i < numbers.Count; i++)
            {
                if (numbers[i] > numbers[i - 3])
                {
                    count++;
                }
            }

            Console.WriteLine($"Day 1, task 2: {count}");
        }
    }
}