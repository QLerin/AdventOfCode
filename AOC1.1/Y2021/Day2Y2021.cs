using System;
using System.Linq;

namespace AOC1._1.Y2021
{
    public class Day2Y2021
    {
        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Coding\AdventOfCode\AOC1.1\Y2021\Data2.txt");
            var x = 0;
            var y = 0;

            foreach (var line in lines)
            {
                var directionWithValue = line.Split(' ');
                var direction = directionWithValue[0];
                var value = int.Parse(directionWithValue[1]);

                switch (direction)
                {
                    case "forward":
                        x += value;
                        break;
                    case "down":
                        y += value;
                        break;
                    case "up":
                        y -= value;
                        break;
                }
            }
            
            Console.WriteLine($"Day 2, task 1: {x * y}");
        }

        public static void Task2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Coding\AdventOfCode\AOC1.1\Y2021\Data2.txt");
            var x = 0;
            var y = 0;
            var aim = 0;

            foreach (var line in lines)
            {
                var directionWithValue = line.Split(' ');
                var direction = directionWithValue[0];
                var value = int.Parse(directionWithValue[1]);

                switch (direction)
                {
                    case "forward":
                        x += value;
                        y += aim * value;
                        break;
                    case "down":
                        aim += value;
                        break;
                    case "up":
                        aim -= value;
                        break;
                }
            }

            Console.WriteLine($"Day 2, task 2: {x * y}");
        }
    }
}