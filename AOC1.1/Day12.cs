using System;

namespace AOC1._1
{
    public class Day12
    {
        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data12.txt");

            var direction = 90;
            int x = 0;
            int y = 0;

            foreach (var line in lines)
            {
                var symbol = line[0];
                var value = int.Parse(line.Substring(1));

                switch (symbol)
                {
                    case 'N':
                        y += value;
                        break;

                    case 'S':
                        y -= value;
                        break;

                    case 'E':
                        x += value;
                        break;

                    case 'W':
                        x -= value;
                        break;

                    case 'L':
                        direction -= value;
                        direction = FixDirection(direction);
                        break;

                    case 'R':
                        direction += value;
                        direction = FixDirection(direction);
                        break;

                    case 'F':
                        switch (direction)
                        {
                            case 0:
                                y += value;
                                break;

                            case 90:
                                x += value;
                                break;

                            case 180:
                                y -= value;
                                break;

                            case 270:
                                x -= value;
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine($"Day 12, task 1: {Math.Abs(x) + Math.Abs(y)}");
        }

        private static int FixDirection(int direction)
        {
            if (direction < 0)
            {
                direction += 360;
            }
            else if (direction >= 360)
            {
                direction -= 360;
            }

            return direction;
        }

        public static void Task2()
        {
        }
    }
}