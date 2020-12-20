using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC1._1
{
    public class Day20
    {
        private class PuzzlePiece
        {
            public PuzzlePiece(int name, List<string> borders)
            {
                Name = name;
                Borders = borders;
                Friends = new List<PuzzlePiece>();
            }

            public int Name { get; }
            public List<string> Borders { get; }
            public List<PuzzlePiece> Friends { get; }

            public List<string> GetBorderKeys()
            {
                if (_bordersKeys == null)
                {
                    var borderKeys = Borders.ToList();
                    borderKeys.AddRange(Borders.Select(border => new string(border.Reverse().ToArray())));
                    _bordersKeys = borderKeys;
                }

                return _bordersKeys;
            }
            
            private List<string> _bordersKeys;

            public bool IsFriendly(PuzzlePiece other)
            {
                var keys = GetBorderKeys();
                var otherKeys = other.GetBorderKeys();
                return keys.Any(key => otherKeys.Any(otherKey => key == otherKey));
            }
        }
        
        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data20.txt");

            var puzzlePieces = GetPuzzlePieces(lines);

            for (var i = 0; i < puzzlePieces.Count - 1; i++)
            {
                for (var y = 1; y < puzzlePieces.Count; y++)
                {
                    if (i == y || puzzlePieces[i].Friends.Contains(puzzlePieces[y]))
                    {
                        continue;
                    }

                    if (puzzlePieces[i].IsFriendly(puzzlePieces[y]))
                    {
                        puzzlePieces[i].Friends.Add(puzzlePieces[y]);
                        puzzlePieces[y].Friends.Add(puzzlePieces[i]);
                    }
                }
            }
            
            var sum = puzzlePieces.Where(piece => piece.Friends.Count == 2).Aggregate((long) 1, (total, piece) => total * piece.Name);
            Console.WriteLine($"Day 20, task 1: {sum}");
        }

        private static List<PuzzlePiece> GetPuzzlePieces(string[] lines)
        {
            var puzzlePieces = new List<PuzzlePiece>();

            var isName = true;
            var rows = new List<string>();
            int name = 0;

            foreach (var line in lines)
            {
                if (line == "")
                {
                    isName = true;
                    puzzlePieces.Add(GetPuzzlePiece(rows, name));
                    rows = new List<string>();
                    continue;
                }

                if (isName)
                {
                    var secondPart = line.Split(" ")[1];
                    name = int.Parse(secondPart.Substring(0, secondPart.Length - 1));
                    isName = false;
                }
                else
                {
                    rows.Add(line);
                }
            }

            puzzlePieces.Add(GetPuzzlePiece(rows, name));
            return puzzlePieces;
        }

        private static PuzzlePiece GetPuzzlePiece(List<string> rows, int name)
        {
            var top = rows.First();
            var bot = rows.Last();
            var left = "";
            var right = "";

            foreach (var row in rows)
            {
                left += row[0];
                right += row[^1];
            }

            var piece = new PuzzlePiece(name, new List<string> {top, right, bot, left});
            return piece;
        }

        public static void Task2()
        {

        }
    }
}
