using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AOC1._1
{
    public class Day24
    {
        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data24.txt");
            
            var flippedTiles = GetFlippedTiles(lines);

            Console.WriteLine($"Day 24, task 1: {flippedTiles.Count}");
        }

        private static HashSet<Point> GetFlippedTiles(string[] lines)
        {
            var flippedTiles = new HashSet<Point>();

            foreach (var line in lines)
            {
                var currentTile = new Point();
                var instructions = line;
                while (instructions.Any())
                {
                    if (instructions[0] == 'e')
                    {
                        currentTile = new Point(currentTile.X + 1, currentTile.Y);
                        instructions = instructions.Substring(1);
                        continue;
                    }

                    if (instructions[0] == 's' && instructions[1] == 'e')
                    {
                        currentTile = new Point(currentTile.X + 1, currentTile.Y - 1);
                        instructions = instructions.Substring(2);
                        continue;
                    }

                    if (instructions[0] == 's' && instructions[1] == 'w')
                    {
                        currentTile = new Point(currentTile.X, currentTile.Y - 1);
                        instructions = instructions.Substring(2);
                        continue;
                    }

                    if (instructions[0] == 'w')
                    {
                        currentTile = new Point(currentTile.X - 1, currentTile.Y);
                        instructions = instructions.Substring(1);
                        continue;
                    }

                    if (instructions[0] == 'n' && instructions[1] == 'w')
                    {
                        currentTile = new Point(currentTile.X - 1, currentTile.Y + 1);
                        instructions = instructions.Substring(2);
                        continue;
                    }

                    if (instructions[0] == 'n' && instructions[1] == 'e')
                    {
                        currentTile = new Point(currentTile.X, currentTile.Y + 1);
                        instructions = instructions.Substring(2);
                        continue;
                    }
                }

                if (flippedTiles.Contains(currentTile))
                {
                    flippedTiles.Remove(currentTile);
                }
                else
                {
                    flippedTiles.Add(currentTile);
                }
            }

            return flippedTiles;
        }

        public static void Task2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data24.txt");

            var blackTiles = GetFlippedTiles(lines);

            for (var i = 0; i < 100; i++)
            {
                var tilesWithoutBlack = blackTiles.SelectMany(GetNeighboursPoints).ToHashSet();
                foreach (var tile in blackTiles)
                {
                    tilesWithoutBlack.Remove(tile);
                }

                var newBlacks = new HashSet<Point>();
                foreach (var black in blackTiles)
                {
                    var count = GetNeighboursPoints(black).Count(tile => blackTiles.Contains(tile));
                    if (count != 0 && count <= 2)
                    {
                        newBlacks.Add(black);
                    }
                }

                foreach (var tileWithoutBlack in tilesWithoutBlack)
                {
                    var count = GetNeighboursPoints(tileWithoutBlack).Count(tile => blackTiles.Contains(tile));
                    if (count == 2)
                    {
                        newBlacks.Add(tileWithoutBlack);
                    }
                }

                blackTiles = newBlacks;
            }

            Console.WriteLine($"Day 24, task 2: {blackTiles.Count}");
        }

        private static List<Point> GetNeighboursPoints(Point point)
        {
            return new List<Point>
            {
                new Point(point.X + -1, point.Y + 1),
                new Point(point.X + 0, point.Y + 1),
                new Point(point.X + -1, point.Y + 0),
                new Point(point.X + 1, point.Y + 0),
                new Point(point.X + 0, point.Y - 1),
                new Point(point.X + 1, point.Y - 1),
            };
        }
    }
}
