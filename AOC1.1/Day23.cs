using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC1._1
{
    public class Day23
    {
        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data23.txt");
            var numbers = lines.First().Select(character => int.Parse("" + character)).ToList();

            var moves = 100;
            var current = 0;
            var max = numbers.Max();
            var min = numbers.Min();
            while (moves > 0)
            {
                moves--;
                var currentNumber = numbers[current];

                var indexes = new List<int>();
                for (var i = 1; i < 4; i++)
                {
                    var index = ((current + i) < numbers.Count) ? current + i : current + i - numbers.Count;
                    indexes.Add(index);
                }

                List<int> taken = indexes.Select(index => numbers[index]).ToList();
                taken.ForEach(number => numbers.Remove(number));

                var destination = currentNumber - 1;
                while (!numbers.Contains(destination))
                {
                    destination--;
                    if (destination < min)
                    {
                        destination = max;
                    }
                }

                var destinationIndex = numbers.FindIndex(0, number => number == destination) + 1;
                numbers.InsertRange(destinationIndex, taken);

                current = numbers.FindIndex(0, number => number == currentNumber) + 1;
                if (current >= numbers.Count)
                {
                    current = 0;
                }
            }

            numbers.AddRange(numbers);
            string result = "";

            var startIndex = numbers.FindIndex(0, number => number == 1) + 1;
            var endIndex = numbers.FindIndex(startIndex, number => number == 1);
            for (var i = startIndex; i < endIndex; i++)
            {
                result += numbers[i];
            }

            Console.WriteLine($"Day 23, task 1: {result}");
        }

        public static void Task2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data23.txt");
            var numbers = lines.First().Select(character => int.Parse("" + character)).ToList();
            var nextNumber = numbers.Count + 1;
            for (var i = nextNumber; i <= 1000000; i++)
            {
                numbers.Add(i);
            }

            var moves = 10000000;
            var current = 0;
            var max = numbers.Max();
            var min = numbers.Min();
            while (moves > 0)
            {
                moves--;
                var currentNumber = numbers[current];

                var indexes = new List<int>();
                for (var i = 1; i < 4; i++)
                {
                    var index = ((current + i) < numbers.Count) ? current + i : current + i - numbers.Count;
                    indexes.Add(index);
                }

                List<int> taken = indexes.Select(index => numbers[index]).ToList();
                taken.ForEach(number => numbers.Remove(number));

                var destination = currentNumber - 1;
                while (!numbers.Contains(destination))
                {
                    destination--;
                    if (destination < min)
                    {
                        destination = max;
                    }
                }

                var destinationIndex = numbers.FindIndex(0, number => number == destination) + 1;
                numbers.InsertRange(destinationIndex, taken);

                current = numbers.FindIndex(0, number => number == currentNumber) + 1;
                if (current >= numbers.Count)
                {
                    current = 0;
                }
            }

            numbers.AddRange(numbers);

            var startIndex = numbers.FindIndex(0, number => number == 1);
            var result = numbers[startIndex + 1] * numbers[startIndex + 2];

            Console.WriteLine($"Day 23, task 2: {result}");
        }
    }
}