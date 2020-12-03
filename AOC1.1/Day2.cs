using System;

namespace AOC1._1
{
    public class Day2
    {
        public static void Task1()
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
            Console.WriteLine($"Day 2, task 1: {correctStringsCount}");
        }

        public static void Task2()
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
            Console.WriteLine($"Day 2, task 2: {correctStringsCount}");
        }
    }
}