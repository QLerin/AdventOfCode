using System;
using System.Collections.Generic;
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
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data10.txt");
            var numbers = lines.Select(line => int.Parse(line)).OrderBy(number => number).ToList();
            numbers.Insert(0, 0);

            var splits = new List<List<int>>();
            var numbersGroup = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbersGroup.Count == 0 || numbers[i] - numbersGroup.Last() < 3)
                {
                    numbersGroup.Add(numbers[i]);
                    continue;
                }

                splits.Add(numbersGroup);
                numbersGroup = new List<int> { numbers[i] };
            }
            splits.Add(numbersGroup);

            long count = 1;
            foreach (var group in splits)
            {
                long tempCount = 0;
                RecursiveSearch(group, group.Count - 1, ref tempCount);
                count *= tempCount;
            }

            Console.WriteLine($"Day 10, task 2: {count}");
        }

        private static void RecursiveSearch(List<int> numbers, int index, ref long count)
        {
            var validIndexes = GetValidIndexes(numbers, index);
            if (validIndexes.Count == 0)
            {
                count++;
                return;
            }

            if (numbers[index] - numbers.First() <= 3)
            {
                count++;
            }

            foreach (var validIndex in validIndexes)
            {
                RecursiveSearch(numbers, validIndex, ref count);
            }
        }

        private static List<int> GetValidIndexes(List<int> numbers, int index)
        {
            var validIndexes = new List<int>();
            var number = numbers[index];

            if (index - 1 > 0 && number - numbers[index - 1] <= 3)
            {
                validIndexes.Add(index - 1);
            }

            if (index - 2 > 0 && number - numbers[index - 2] <= 3)
            {
                validIndexes.Add(index - 2);
            }

            if (index - 3 > 0 && number - numbers[index - 3] <= 3)
            {
                validIndexes.Add(index - 3);
            }

            return validIndexes;
        }
    }
}