using System;
using System.Linq;

namespace AOC1._1
{
    public class Day3
    {
        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data3.txt");
            int treesCount = GetTreesCount(lines, 3, 1);
            Console.WriteLine($"Day 3, task 1: {treesCount}");
        }

        public static void Task2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data3.txt");
            int treesCount11 = GetTreesCount(lines, 1, 1);
            int treesCount31 = GetTreesCount(lines, 3, 1);
            int treesCount51 = GetTreesCount(lines, 5, 1);
            int treesCount71 = GetTreesCount(lines, 7, 1);
            int treesCount12 = GetTreesCount(lines, 1, 2);
            var multiplication = treesCount11 * treesCount31 * treesCount51 * treesCount71 * treesCount12;
            Console.WriteLine($"Day 3, task 2: {multiplication}");
        }

        private static int GetTreesCount(string[] lines, int xIncrement, int yIncrement)
        {
            int columnsCount = lines.First().Length;

            int startingX = 0;
            int treesCount = 0;
            for (int i = 0; i < lines.Length; i += yIncrement)
            {
                var charArray = lines[i].ToCharArray();

                if (startingX >= columnsCount)
                {
                    startingX -= columnsCount;
                }

                if (charArray[startingX] == '#')
                {
                    treesCount++;
                }

                startingX += xIncrement;
            }

            return treesCount;
        }
    }
}