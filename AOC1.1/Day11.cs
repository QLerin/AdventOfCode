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
                var updatedRows = DoRoundOld(seatsRows);
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

        private static List<string> DoRoundOld(List<string> seatsRows)
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
                        int occupiedCount = GetSymbolCountInAdjacentOld(seatsRows, rowLength, row, column, '#');
                        if (occupiedCount == 0)
                        {
                            rowString += '#';
                            continue;
                        }
                    }
                    if (currentSeat == '#')
                    {
                        int occupiedCount = GetSymbolCountInAdjacentOld(seatsRows, rowLength, row, column, '#');
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

        private static int GetSymbolCountInAdjacentOld(List<string> seatsRows, int rowLength, int row, int column, char symbol)
        {
            int count = 0;

            if (IsSameSymbolOld(seatsRows, rowLength, symbol, row - 1, column - 1))
            {
                count++;
            }

            if (IsSameSymbolOld(seatsRows, rowLength, symbol, row - 1, column))
            {
                count++;
            }

            if (IsSameSymbolOld(seatsRows, rowLength, symbol, row - 1, column + 1))
            {
                count++;
            }

            if (IsSameSymbolOld(seatsRows, rowLength, symbol, row, column - 1))
            {
                count++;
            }

            if (IsSameSymbolOld(seatsRows, rowLength, symbol, row, column + 1))
            {
                count++;
            }

            if (IsSameSymbolOld(seatsRows, rowLength, symbol, row + 1, column - 1))
            {
                count++;
            }

            if (IsSameSymbolOld(seatsRows, rowLength, symbol, row + 1, column))
            {
                count++;
            }

            if (IsSameSymbolOld(seatsRows, rowLength, symbol, row + 1, column + 1))
            {
                count++;
            }

            return count;
        }

        private static bool IsSameSymbolOld(List<string> seatsRows, int rowLength, char symbol, int tempRow, int tempColumn)
        {
            if (tempRow >= 0 && tempRow < seatsRows.Count && tempColumn >= 0 && tempColumn < rowLength && seatsRows[tempRow][tempColumn] == symbol)
            {
                return true;
            }

            return false;
        }

        public static void Task2()
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

            Console.WriteLine($"Day 11, task 2: {count}");
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
                        int occupiedCount = GetOccupiedCount(seatsRows, rowLength, row, column);
                        if (occupiedCount == 0)
                        {
                            rowString += '#';
                            continue;
                        }
                    }
                    if (currentSeat == '#')
                    {
                        int occupiedCount = GetOccupiedCount(seatsRows, rowLength, row, column);
                        if (occupiedCount >= 5)
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

        private static int GetOccupiedCount(List<string> seatsRows, int rowLength, int row, int column)
        {
            int count = 0;

            if (IsOccupied(seatsRows, rowLength, row, column, -1, -1))
            {
                count++;
            }

            if (IsOccupied(seatsRows, rowLength, row, column, -1, 0))
            {
                count++;
            }

            if (IsOccupied(seatsRows, rowLength, row, column, -1, 1))
            {
                count++;
            }

            if (IsOccupied(seatsRows, rowLength, row, column, 0, -1))
            {
                count++;
            }

            if (IsOccupied(seatsRows, rowLength, row, column, 0, 1))
            {
                count++;
            }

            if (IsOccupied(seatsRows, rowLength, row, column, 1, -1))
            {
                count++;
            }

            if (IsOccupied(seatsRows, rowLength, row, column, 1, 0))
            {
                count++;
            }

            if (IsOccupied(seatsRows, rowLength, row, column, 1, 1))
            {
                count++;
            }

            return count;
        }

        private static bool IsOccupied(List<string> seatsRows, int rowLength, int row, int column, int indexRow, int indexColumn)
        {
            var tempRow = row + indexRow;
            var tempColumn = column + indexColumn;

            while (tempRow >= 0 && tempRow < seatsRows.Count && tempColumn >= 0 && tempColumn < rowLength)
            {
                if (seatsRows[tempRow][tempColumn] == '#')
                {
                    return true;
                }

                if (seatsRows[tempRow][tempColumn] == 'L')
                {
                    return false;
                }

                tempRow = tempRow + indexRow;
                tempColumn = tempColumn + indexColumn;
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