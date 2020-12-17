using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC1._1
{
    public class Day17
    {
        public class Position
        {
            public Position(int x, int y, int z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public int X { get; }

            protected bool Equals(Position other)
            {
                return X == other.X && Y == other.Y && Z == other.Z;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Position)obj);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(X, Y, Z);
            }

            public static bool operator ==(Position left, Position right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(Position left, Position right)
            {
                return !Equals(left, right);
            }

            public int Y { get; }
            public int Z { get; }
        }

        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data17.txt");
            var starting = new Dictionary<Position, bool>();

            var size = lines.Length;
            var startingSize = size;
            var zLevel = 0;

            for (var y = 0; y < lines.Length; y++)
            {
                for (var x = 0; x < lines[y].Length; x++)
                {
                    var isActive = lines[x][y] == '#';
                    starting[new Position(x, y, 0)] = isActive;
                }
            }

            for (var i = 0; i < 6; i++)
            {
                var temporaryDictionary = new Dictionary<Position, bool>();
                size += 2;
                zLevel++;
                for (var tempX = 0; tempX < size; tempX++)
                {
                    for (var tempY = 0; tempY < size; tempY++)
                    {
                        var modifier = (startingSize - size) / 2;
                        for (var z = -zLevel; z <= zLevel; z++)
                        {
                            temporaryDictionary[new Position(tempX + modifier, tempY + modifier, z)] = false;
                        }
                    }
                }

                foreach (var key in temporaryDictionary.Keys.ToList())
                {
                    var currentValue = TryToGetValue(starting, key);
                    var nearActive = NearbyPositions(key)
                        .Count(position => TryToGetValue(starting, position));
                    if (currentValue)
                    {
                        temporaryDictionary[key] = nearActive == 2 || nearActive == 3;
                    }
                    else
                    {
                        temporaryDictionary[key] = nearActive == 3;
                    }
                }

                starting = temporaryDictionary;
            }

            Console.WriteLine($"Day 17, task 1: {starting.Count(valueKey => valueKey.Value)}");
        }

        public static bool TryToGetValue(Dictionary<Position, bool> dictionary, Position position)
        {
            return dictionary.ContainsKey(position) && dictionary[position];
        }

        public static List<Position> NearbyPositions(Position currentPosition)
        {
            var nearby = new List<Position>();
            for (var x = currentPosition.X - 1; x <= currentPosition.X + 1; x++)
            {
                for (var y = currentPosition.Y - 1; y <= currentPosition.Y + 1; y++)
                {
                    for (var z = currentPosition.Z - 1; z <= currentPosition.Z + 1; z++)
                    {
                        var position = new Position(x, y, z);
                        if (currentPosition != position)
                        {
                            nearby.Add(position);
                        }
                    }
                }
            }

            return nearby;
        }

        public static void Task2()
        {
        }
    }
}