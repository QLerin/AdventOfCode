using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC1._1.Y2021
{
    public class Day5Y2021
    {
        public static void Task1()
        {
            var lines = System.IO.File.ReadAllLines(@"C:\Coding\AdventOfCode\AOC1.1\Y2021\Data5.txt");
            var dictionary = new Dictionary<(int, int), int>();

            foreach (var line in lines)
            {
                var parts = line.Split(" -> ");
                var from = parts[0].Split(',');
                var to = parts[1].Split(',');
                var fromX = int.Parse(from[0]);
                var fromY = int.Parse(from[1]);
                var toX = int.Parse(to[0]);
                var toY = int.Parse(to[1]);

                if (fromX == toX)
                {
                    AddYValues(fromY, toY, fromX, dictionary);
                    continue;
                }

                if (fromY == toY)
                {
                    AddXValues(fromX, toX, fromY, dictionary);

                    continue;
                }
            }

            Console.WriteLine($"Day 5, task 1: {dictionary.Values.Where(count => count > 1).Count()}");
        }

        public static void Task2()
        {
            var lines = System.IO.File.ReadAllLines(@"C:\Coding\AdventOfCode\AOC1.1\Y2021\Data5.txt");
            var dictionary = new Dictionary<(int, int), int>();

            foreach (var line in lines)
            {
                var parts = line.Split(" -> ");
                var from = parts[0].Split(',');
                var to = parts[1].Split(',');
                var fromX = int.Parse(from[0]);
                var fromY = int.Parse(from[1]);
                var toX = int.Parse(to[0]);
                var toY = int.Parse(to[1]);

                if (fromX == toX)
                {
                    AddYValues(fromY, toY, fromX, dictionary);
                    continue;
                }

                if (fromY == toY)
                {
                    AddXValues(fromX, toX, fromY, dictionary);

                    continue;
                }

                if (fromX != toX && fromY != toY)
                {
                    AddDiagonal(toX, fromX, toY, fromY, dictionary);
                }
            }

            Console.WriteLine($"Day 5, task 2: {dictionary.Values.Where(count => count > 1).Count()}");
        }

        private static void AddDiagonal(int toX, int fromX, int toY, int fromY, Dictionary<(int, int), int> dictionary)
        {
            var vectorX = Math.Sign(toX - fromX);
            var vectorY = Math.Sign(toY - fromY);

            var currentX = fromX;
            var currentY = fromY;
            while (currentX != toX + vectorX && currentY != toY + vectorY)
            {
                AddField(currentX, currentY, dictionary);
                currentX += vectorX;
                currentY += vectorY;
            }
        }

        private static void AddXValues(int fromX, int toX, int fromY, Dictionary<(int, int), int> dictionary)
        {
            var minX = Math.Min(fromX, toX);
            var maxX = Math.Max(fromX, toX);
            for (var x = minX; x <= maxX; x++)
            {
                AddField(x, fromY, dictionary);
            }
        }

        private static void AddYValues(int fromY, int toY, int fromX, Dictionary<(int, int), int> dictionary)
        {
            var minY = Math.Min(fromY, toY);
            var maxY = Math.Max(fromY, toY);
            for (var y = minY; y <= maxY; y++)
            {
                AddField(fromX, y, dictionary);
            }
        }

        private static void AddField(int x, int y, Dictionary<(int, int), int> dictionary)
        {
            if (dictionary.ContainsKey((x, y)))
            {
                dictionary[(x, y)]++;
            }
            else
            {
                dictionary[(x, y)] = 1;
            }
        }
    }
}