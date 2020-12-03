using System;
using System.Linq;

namespace AOC1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            AOC1_1();
        }

        private static void AOC1_1()
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
                        Console.WriteLine((numbers[x] * numbers[i]).ToString());
                        return;
                    }
                }
            }
        }

        private static void AOC1_2()
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
                            Console.WriteLine((numbers[x] * numbers[i] * numbers[y]).ToString());
                            return;
                        }
                    }
                }
            }
        }

        private static void AOC2_1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data2.1.txt");
            var correctStringsCount = 0;
            foreach (var line in lines)
            {
                var stringParts = line.Split(" ");
                var minMax = stringParts[0].Split("-");
                var min = int.Parse(minMax[0]);
                var max = int.Parse(minMax[1]);
                var letter = stringParts[1].Substring(0, 1);
                int count = 0;
                foreach (var passwordLetter in stringParts[2])
                {
                    if (passwordLetter.ToString() == letter)
                    {
                        count++;
                    }
                }
                if (count >= min && count <= max)
                {
                    correctStringsCount++;
                }
            }
            Console.WriteLine(correctStringsCount.ToString());
        }

        private static void AOC2_2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data2.2.txt");
            var correctStringsCount = 0;
            foreach (var line in lines)
            {
                var stringParts = line.Split(" ");
                var firstSecond = stringParts[0].Split("-");
                var first = int.Parse(firstSecond[0]) - 1;
                var second = int.Parse(firstSecond[1]) - 1;
                var letter = stringParts[1].Substring(0, 1);
                int count = 0;
                var charArray = stringParts[2];

                if (charArray[first].ToString() == letter)
                {
                    count++;
                }

                if (charArray[second].ToString() == letter)
                {
                    count++;
                }

                if (count == 1)
                {
                    correctStringsCount++;
                }

            }
            Console.WriteLine(correctStringsCount.ToString());
        }

        private static void AOC3_1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data3.1.txt");
            int treesCount = 0;
            int startingX = 0;
            int rowsCount = lines.First().Length;
            foreach (var line in lines)
            {
                var charArray = line.ToCharArray();

                if (startingX >= rowsCount)
                {
                    startingX -= rowsCount;
                }

                if (charArray[startingX] == '#')
                {
                    treesCount++;
                }
                startingX += 3;

            }
            Console.WriteLine(treesCount.ToString());
        }

        private static void AOC3_2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data3.2.txt");
            int treesCount11 = GetTreesCount(lines, 1, 1);
            int treesCount31 = GetTreesCount(lines, 3, 1);
            int treesCount51 = GetTreesCount(lines, 5, 1);
            int treesCount71 = GetTreesCount(lines, 7, 1);
            int treesCount12 = GetTreesCount(lines, 1, 2);
            Console.WriteLine(treesCount11 * treesCount31 * treesCount51 * treesCount71 * treesCount12);
        }

        private static int GetTreesCount(string[] lines, int xIncrement, int yIncrement)
        {
            int rowsCount = lines.First().Length;
            int startingX = 0;
            int treesCount = 0;
            for (int i = 0; i < lines.Length; i += yIncrement)
            {
                var charArray = lines[i].ToCharArray();

                if (startingX >= rowsCount)
                {
                    startingX -= rowsCount;
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
