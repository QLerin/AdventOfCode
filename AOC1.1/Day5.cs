using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC1._1
{
    public class Day5
    {
        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data5.txt");
            var rows = 128;
            var columns = 8;
            var highestId = 0;

            foreach (var line in lines)
            {
                var upDownStart = 0;
                var upDownEnding = rows;
                var leftRightStart = 0;
                var leftRightEnding = columns;

                var upDownPart = line.Substring(0, 7);
                var leftRightPart = line.Substring(7, 3);

                foreach (var symbol in upDownPart)
                {
                    var distance = (upDownEnding - upDownStart) / 2;
                    if (symbol == 'F')
                    {
                        upDownEnding -= distance;
                    }
                    else
                    {
                        upDownStart += distance;
                    }
                }

                foreach (var symbol in leftRightPart)
                {
                    var distance = (leftRightEnding - leftRightStart) / 2;
                    if (symbol == 'L')
                    {
                        leftRightEnding -= distance;
                    }
                    else
                    {
                        leftRightStart += distance;
                    }
                }

                highestId = Math.Max(highestId, upDownStart * 8 + leftRightStart);
            }

            Console.WriteLine($"Day 5, task 1: {highestId}");
        }

        public static void Task2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data5.txt");
            var rows = 128;
            var columns = 8;
            var takenSeats = new SortedDictionary<int, List<int>>();

            foreach (var line in lines)
            {
                var upDownPart = line.Substring(0, 7);
                var leftRightPart = line.Substring(7, 3);

                var binaryRow = GetNumber(upDownPart, 'B');
                var binaryColumn = GetNumber(leftRightPart, 'R');

                if (takenSeats.ContainsKey(binaryRow))
                {
                    takenSeats[binaryRow].Add(binaryColumn);
                }
                else
                {
                    takenSeats[binaryRow] = new List<int> { binaryColumn };
                }
            }

            List<int> availableIds = GetAvailableIds(columns, takenSeats);

            var correctId = availableIds.First(id => !availableIds.Contains(id - 1) && !availableIds.Contains(id + 1));
            Console.WriteLine($"Day 5, task 2: {correctId}");
        }

        private static int GetNumber(string text, char upSymbol)
        {
            var number = 0;
            var count = text.Length;

            for (int i = 0; i < count; i++)
            {
                if (text[i] == upSymbol)
                {
                    number += (int)Math.Pow(2, count - (i + 1));
                }
            }
            return number;
        }

        private static List<int> GetAvailableIds(int columns, SortedDictionary<int, List<int>> takenSeats)
        {
            var availableIds = new List<int>();
            var maxRow = takenSeats.Keys.Max(key => key);
            var minRow = takenSeats.Keys.Min(key => key);

            for (int row = minRow; row <= maxRow; row++)
            {
                if (takenSeats.ContainsKey(row))
                {
                    for (int tempColumn = 0; tempColumn < columns; tempColumn++)
                    {
                        if (takenSeats[row].Contains(tempColumn))
                        {
                            continue;
                        }
                        availableIds.Add(row * 8 + tempColumn);
                    }
                }
                else
                {
                    //There is chance that whole row is missing but that's not in our data
                    for (int column = 0; column < columns; column++)
                    {
                        availableIds.Add(row * 8 + column);
                    }
                }
            }

            return availableIds;
        }
    }
}