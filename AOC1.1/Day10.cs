using System;
using System.Linq;

namespace AOC1._1
{
    public class Day10
    {
        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data10.txt");
            var numbers = lines.Select(line => int.Parse(line)).ToList();
            int oneDifference = 0;
            int threeDifference = 1;

            int lastNumber = 0;
            foreach (var number in numbers.OrderBy(number => number))
            {
                var diff = number - lastNumber;
                if (diff == 1)
                {
                    oneDifference++;
                }
                else if (diff == 3)
                {
                    threeDifference++;
                }

                lastNumber = number;
            }

            Console.WriteLine($"Day 10, task 1: {oneDifference * threeDifference}");
        }

        public static void Task2()
        {
        }
    }
}