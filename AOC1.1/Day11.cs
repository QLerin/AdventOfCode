using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC1._1
{
    public class Day11
    {
        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data11.txt");

            var seatsRows = lines.ToList();
            while (true)
            {
                var updatedRows = DoRound(seatsRows);
                if (Compare(seatsRows, updatedRows))
                {
                    seatsRows = updatedRows;
                    break;
                }
                seatsRows = updatedRows;
            }

            var count = 0;
            foreach (var seatRow in seatsRows)
            {
                foreach (var seat in seatRow)
                {
                    if (seat == '#')
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine($"Day 11, task 1: {count}");
        }

        public static void Task2()
        {
        }

        private static List<string> DoRound(List<string> seatsRows)
        {
            var updatedSeats = new List<string>();
            var rowLength = seatsRows.First().Length;

            for (int row = 0; row < seatsRows.Count; row++)
            {
                var rowString = "";
                for (int column = 0; column < rowLength; column++)
                {
                    var currentSeat = seatsRows[row][column];
                    if (currentSeat == 'L')
                    {
                        int occupiedCount = GetSymbolCountInAdjacent(seatsRows, rowLength, row, column, '#');
                        if (occupiedCount == 0)
                        {
                            rowString += '#';
                            continue;
                        }
                    }
                    if (currentSeat == '#')
                    {
                        int occupiedCount = GetSymbolCountInAdjacent(seatsRows, rowLength, row, column, '#');
                        if (occupiedCount >= 4)
                        {
                            rowString += 'L';
                            continue;
                        }
                    }

                    rowString += currentSeat;
                }
                updatedSeats.Add(rowString);
            }

            return updatedSeats;
        }

        private static int GetSymbolCountInAdjacent(List<string> seatsRows, int rowLength, int row, int column, char symbol)
        {
            int count = 0;

            if (IsSameSymbol(seatsRows, rowLength, symbol, row - 1, column - 1))
            {
                count++;
            }

            if (IsSameSymbol(seatsRows, rowLength, symbol, row - 1, column))
            {
                count++;
            }

            if (IsSameSymbol(seatsRows, rowLength, symbol, row - 1, column + 1))
            {
                count++;
            }

            if (IsSameSymbol(seatsRows, rowLength, symbol, row, column - 1))
            {
                count++;
            }

            if (IsSameSymbol(seatsRows, rowLength, symbol, row, column + 1))
            {
                count++;
            }

            if (IsSameSymbol(seatsRows, rowLength, symbol, row + 1, column - 1))
            {
                count++;
            }

            if (IsSameSymbol(seatsRows, rowLength, symbol, row + 1, column))
            {
                count++;
            }

            if (IsSameSymbol(seatsRows, rowLength, symbol, row + 1, column + 1))
            {
                count++;
            }

            return count;
        }

        private static bool IsSameSymbol(List<string> seatsRows, int rowLength, char symbol, int tempRow, int tempColumn)
        {
            if (tempRow >= 0 && tempRow < seatsRows.Count && tempColumn >= 0 && tempColumn < rowLength && seatsRows[tempRow][tempColumn] == symbol)
            {
                return true;
            }

            return false;
        }

        private static bool Compare(List<string> previous, List<string> current)
        {
            for (int i = 0; i < previous.Count; i++)
            {
                if (previous[i] != current[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}