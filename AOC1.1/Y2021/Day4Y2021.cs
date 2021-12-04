using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC1._1.Y2021
{
    public class Day4Y2021
    {
        public static void Task1()
        {
            var lines = System.IO.File.ReadAllLines(@"C:\Coding\AdventOfCode\AOC1.1\Y2021\Data4.txt").ToList();
            var numbers = lines[0].Split(',').Select(int.Parse);

            lines.RemoveAt(0);
            lines.RemoveAt(0);

            var listrosity = GetListrosity(lines);

            foreach (var number in numbers)
            {
                FillNumber(listrosity, number);
                foreach (var matrix in listrosity)
                {
                    if (IsMatrixWon(matrix))
                    {
                        var score = matrix.Sum(row => row.Where(numberWithBool => !numberWithBool.Used).Sum(notUsedNumber => notUsedNumber.Number));
                        Console.WriteLine($"Day 4, task 1: {score * number}");
                        return;
                    }
                }
            }
        }

        public static bool IsMatrixWon(List<List<NumberWithBool>> matrix)
        {
            foreach (var row in matrix)
            {
                if (row.All(numberWithBool => numberWithBool.Used))
                {
                    return true;
                }
            }

            for (int i = 0; i < matrix.First().Count; i++)
            {
                if (matrix.All(row => row[i].Used))
                {
                    return true;
                }
            }

            return false;
        }

        public static void Task2()
        {
            var lines = System.IO.File.ReadAllLines(@"C:\Coding\AdventOfCode\AOC1.1\Y2021\Data4.txt").ToList();
            var numbers = lines[0].Split(',').Select(int.Parse);

            lines.RemoveAt(0);
            lines.RemoveAt(0);

            var listrosity = GetListrosity(lines);

            var lastScore = 0;
            foreach (var number in numbers)
            {
                FillNumber(listrosity, number);

                foreach (var matrix in listrosity.ToList())
                {
                    if (IsMatrixWon(matrix))
                    {
                        var score = matrix.Sum(row => row.Where(numberWithBool => !numberWithBool.Used).Sum(notUsedNumber => notUsedNumber.Number));
                        lastScore = score * number;
                        listrosity.Remove(matrix);
                    }
                }
            }

            Console.WriteLine($"Day 4, task 2: {lastScore}");
        }

        private static List<List<List<NumberWithBool>>> GetListrosity(List<string> lines)
        {
            var listrosity = new List<List<List<NumberWithBool>>>();

            var matrix = new List<List<NumberWithBool>>();
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    listrosity.Add(matrix);
                    matrix = new List<List<NumberWithBool>>();
                    continue;
                }

                matrix.Add(line.Split(' ').Where(notFilteredNumberText => !string.IsNullOrEmpty(notFilteredNumberText)).Select(numberText => new NumberWithBool(int.Parse(numberText), false)).ToList());
            }

            listrosity.Add(matrix);
            return listrosity;
        }

        private static void FillNumber(List<List<List<NumberWithBool>>> listrosity, int number)
        {
            foreach (var matrix in listrosity)
            {
                foreach (var row in matrix)
                {
                    foreach (var numberWithBool in row)
                    {
                        if (numberWithBool.Number == number)
                        {
                            numberWithBool.Used = true;
                        }
                    }
                }
            }
        }

        //Dictionary with row column would be much faster but idc
        public class NumberWithBool
        {
            public NumberWithBool(int number, bool used)
            {
                Number = number;
                Used = used;
            }

            public int Number { get; set; }

            public bool Used { get; set; }
        }
    }
}