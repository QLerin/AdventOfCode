using System;
using System.Linq;

namespace AOC1._1
{
    public class Day1
    {
        public static void Task1()
        {
            //TODO replace with relative call
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data1.1.txt");
            var numbers = lines.Select(line => int.Parse(line)).ToList();

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                for (int x = 1; x < numbers.Count; x++)
                {
                    if (numbers[x] + numbers[i] == 2020)
                    {
                        var multiplication = numbers[x] * numbers[i];
                        Console.WriteLine($"Day 1, task 1: {multiplication}");
                        return;
                    }
                }
            }
        }

        public static void Task2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data1.2.txt");
            var numbers = lines.Select(line => int.Parse(line)).ToList();

            for (int i = 0; i < numbers.Count - 2; i++)
            {
                for (int x = 1; x < numbers.Count - 1; x++)
                {
                    for (int y = 2; y < numbers.Count; y++)
                    {
                        if (numbers[x] + numbers[i] + numbers[y] == 2020)
                        {
                            var multiplication = numbers[x] * numbers[i] * numbers[y];
                            Console.WriteLine($"Day 1, task 2: {multiplication}");
                            return;
                        }
                    }
                }
            }
        }
    }
}