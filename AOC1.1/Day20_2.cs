using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AOC1._1
{
    public class Day20_2
    {
        private class PuzzlePiece
        {
            public PuzzlePiece(int name, List<string> borders, List<string> fullPicture)
            {
                Name = name;
                Borders = borders;
                FullPicture = fullPicture;
                Friends = new List<PuzzlePiece>();
                CanRotateFlip = true;
            }

            public int Name { get; }
            public List<string> Borders { get; }
            public List<PuzzlePiece> Friends { get; }
            public List<string> FullPicture { get; set; }

            public PuzzlePiece TopFriend { get; set; }
            public PuzzlePiece RightFriend { get; set; }
            public PuzzlePiece BotFriend { get; set; }
            public PuzzlePiece LeftFriend { get; set; }
            public bool CanRotateFlip { get; set; }

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

            public List<List<string>> GetPossibilities()
            {
                if (CanRotateFlip)
                {
                    return GetAllPossible(FullPicture);
                }

                return new List<List<string>> { FullPicture };
            }

            public List<string> InsideImage()
            {
                var inside = new List<string>();
                for (var row = 1; row < FullPicture.Count - 1; row++)
                {
                    inside.Add(FullPicture[row].Substring(1, FullPicture[row].Length - 2));
                }

                return inside;
            }
        }

        public static void Task2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data20.txt");

            var puzzlePieces = GetPuzzlePieces(lines);
            var usedPieces = new HashSet<PuzzlePiece>();

            ConnectPieces(puzzlePieces);
            MatchSide(usedPieces, puzzlePieces.First());

            var startingPiece = puzzlePieces.FirstOrDefault(piece => piece.TopFriend == null && piece.LeftFriend == null);
            var bigBigBigPicture = new List<string>();
            while (startingPiece != null)
            {
                var piecesRows = startingPiece.InsideImage().Select(row => "").ToList();

                var leftPiece = startingPiece;
                while (leftPiece != null)
                {
                    var insideImage = leftPiece.InsideImage();
                    for (int i = 0; i < insideImage.Count; i++)
                    {
                        piecesRows[i] += insideImage[i];
                    }

                    leftPiece = leftPiece.RightFriend;
                }

                bigBigBigPicture.AddRange(piecesRows);
                startingPiece = startingPiece.BotFriend;
            }

            var possibleBigBigPicture = GetAllPossible(bigBigBigPicture);

            var mrsLochnessPoints = new List<Point>
            {
                new Point(-18, 1),
                new Point(-13, 1),
                new Point(-12, 1),
                new Point(-7, 1),
                new Point(-6, 1),
                new Point(-1, 1),
                new Point(0, 1),
                new Point(1, 1),
                new Point(-17, 2),
                new Point(-14, 2),
                new Point(-11, 2),
                new Point(-8, 2),
                new Point(-5, 2),
                new Point(-2, 2),
            };

            List<string> bigBigPicture = null;
            foreach (var picture in possibleBigBigPicture)
            {
                bool correctPosition = false;
                for (var row = 0; row < picture.Count - 2; row++)
                {
                    for (var column = 18; column < picture[row].Length - 1; column++)
                    {
                        if (picture[row][column] == '#')
                        {
                            if (!IsOk(picture, mrsLochnessPoints, row, column))
                            {
                                continue;
                            }

                            ReplaceWithS(picture, mrsLochnessPoints, row, column);
                            correctPosition = true;
                        }
                    }
                }

                if (correctPosition)
                {
                    bigBigPicture = picture;
                    break;
                }
            }

            int count = bigBigPicture.SelectMany(row => row).Count(symbol => symbol == '#');
            Console.WriteLine($"Day 20, task 2: {count}");
        }

        private static bool IsOk(List<string> picture, List<Point> mrsLochnessPoints, int row, int column)
        {
            foreach (var point in mrsLochnessPoints)
            {
                var x = point.X + column;
                var y = point.Y + row;
                if (picture.Count <= y || y < 0 || picture[y].Length <= x || x < 0 || picture[y][x] != '#')
                {
                    return false;
                }
            }

            return true;
        }

        private static void ReplaceWithS(List<string> picture, List<Point> mrsLochnessPoints, int row, int column)
        {
            var copy = mrsLochnessPoints.ToList();
            copy.Add(new Point());
            foreach (var point in copy)
            {
                var x = point.X + column;
                var y = point.Y + row;
                picture[y] = picture[y].Substring(0, x) + "S" + picture[y].Substring(x + 1, picture[y].Length - x - 1);
            }
        }

        private static void MatchSide(HashSet<PuzzlePiece> usedPieces, PuzzlePiece piece)
        {
            piece.CanRotateFlip = false;
            usedPieces.Add(piece);

            var top = GetTop(piece.FullPicture);
            var right = GetRight(piece.FullPicture);
            var bot = GetBot(piece.FullPicture);
            var left = GetLeft(piece.FullPicture);

            foreach (var friend in piece.Friends)
            {
                var possibilities = friend.GetPossibilities();
                foreach (var possibility in possibilities)
                {
                    if (piece.TopFriend == null)
                    {
                        if (top == GetBot(possibility))
                        {
                            piece.TopFriend = friend;
                            friend.BotFriend = piece;
                            friend.FullPicture = possibility;
                            piece.CanRotateFlip = false;
                            continue;
                        }
                    }

                    if (piece.BotFriend == null)
                    {
                        if (bot == GetTop(possibility))
                        {
                            piece.BotFriend = friend;
                            friend.TopFriend = piece;
                            friend.FullPicture = possibility;
                            piece.CanRotateFlip = false;
                            continue;
                        }
                    }
                    
                    if (piece.LeftFriend == null)
                    {
                        if (left == GetRight(possibility))
                        {
                            piece.LeftFriend = friend;
                            friend.RightFriend = piece;
                            friend.FullPicture = possibility;
                            piece.CanRotateFlip = false;
                            continue;
                        }
                    }

                    if (piece.RightFriend == null)
                    {
                        if (right == GetLeft(possibility))
                        {
                            piece.RightFriend = friend;
                            friend.LeftFriend = piece;
                            friend.FullPicture = possibility;
                            piece.CanRotateFlip = false;
                            continue;
                        }
                    }
                }
            }

            var friends = piece.Friends.Where(friend => !usedPieces.Contains(friend));
            foreach (var friend in friends)
            {
                MatchSide(usedPieces, friend);
            }
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

            var piece = new PuzzlePiece(name, new List<string> { top, right, bot, left }, rows);
            return piece;
        }

        private static void ConnectPieces(List<PuzzlePiece> puzzlePieces)
        {
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
        }

        private static List<List<string>> GetAllPossible(List<string> picture)
        {
            var possibilities = new List<List<string>>();

            var picture90 = Rotate(picture);
            var picture180 = Rotate(picture90);
            var picture270 = Rotate(picture180);
            var baseRotations = new List<List<string>> { picture, picture90, picture180, picture270 };
            possibilities.AddRange(baseRotations);

            foreach (var rotation in baseRotations)
            {
                possibilities.Add(FlipHorizontal(rotation));
                possibilities.Add(FlipVertical(rotation));
                possibilities.Add(FlipHorizontal(FlipVertical(rotation)));
            }

            return possibilities;
        }

        private static List<string> Rotate(List<string> picture)
        {
            var rows = picture.Count;
            var columns = picture.First().Length;
            var rotated = new List<string>();
            for (var column = 0; column < columns; column++)
            {
                var newRow = "";
                for (var row = rows - 1; row >= 0; row--)
                {
                    newRow += picture[row][column];
                }
                rotated.Add(newRow);
            }

            return rotated;
        }

        private static List<string> FlipHorizontal(List<string> picture)
        {
            var copy = picture.ToList();
            copy.Reverse();
            return copy;
        }

        private static List<string> FlipVertical(List<string> picture)
        {
            var flipper = new List<string>();
            foreach (var row in picture)
            {
                flipper.Add(new string(row.Reverse().ToArray()));
            }
            return flipper;
        }

        private static string GetTop(List<string> picture)
        {
            return picture.First();
        }

        private static string GetBot(List<string> picture)
        {
            return picture.Last();
        }

        private static string GetLeft(List<string> picture)
        {
            var left = "";
            foreach (var row in picture)
            {
                left += row[0];
            }

            return left;
        }

        private static string GetRight(List<string> picture)
        {
            var right = "";
            foreach (var row in picture)
            {
                right += row[^1];
            }

            return right;
        }
    }
}