using System;
using System.Linq;

namespace AOC1._1.Y2021
{
    public class Day3Y2021
    {
        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Coding\AdventOfCode\AOC1.1\Y2021\Data3.txt");

            var length = lines.First().Length;
            var gammaRate = "";
            var epsilonRate = "";

            for (var i = 0; i < length; i++)
            {
                var zeroCount = 0;
                var oneCount = 0;

                foreach (var line in lines)
                {
                    if (line[i] == '0')
                    {
                        zeroCount++;
                    }
                    else
                    {
                        oneCount++;
                    }
                }

                if (zeroCount > oneCount)
                {
                    gammaRate += "0";
                    epsilonRate += "1";
                }
                else
                {
                    gammaRate += "1";
                    epsilonRate += "0";
                }
            }

            var gamma = Convert.ToInt32(gammaRate, 2);
            var epsilon = Convert.ToInt32(epsilonRate, 2);

            Console.WriteLine($"Day 3, task 1: {gamma * epsilon}");
        }

        public static void Task2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Coding\AdventOfCode\AOC1.1\Y2021\Data3.txt");

            var length = lines.First().Length;
            var oxygenRate = "";
            var co2Rate = "";

            var oxygenLines = lines.ToList();
            for (var i = 0; i < length; i++)
            {
                if (oxygenLines.Count == 1)
                {
                    oxygenRate = oxygenLines.First();
                    break;
                }

                var oxygenLinesCopy = oxygenLines.ToList();
                var zeroCount = 0;
                var oneCount = 0;

                foreach (var line in oxygenLines)
                {
                    if (line[i] == '0')
                    {
                        zeroCount++;
                    }
                    else
                    {
                        oneCount++;
                    }
                }

                char filter = zeroCount > oneCount ? '0' : '1';

                foreach (var line in oxygenLinesCopy)
                {
                    if (line[i] != filter)
                    {
                        oxygenLines.Remove(line);
                    }
                }
            }

            if (string.IsNullOrEmpty(oxygenRate))
            {
                oxygenRate = oxygenLines.First();
            }

            var co2Lines = lines.ToList();
            for (var i = 0; i < length; i++)
            {
                if (co2Lines.Count == 1)
                {
                    co2Rate = co2Lines.First();
                    break;
                }

                var co2LinesCopy = co2Lines.ToList();
                var zeroCount = 0;
                var oneCount = 0;

                foreach (var line in co2Lines)
                {
                    if (line[i] == '0')
                    {
                        zeroCount++;
                    }
                    else
                    {
                        oneCount++;
                    }
                }

                char filter = zeroCount <= oneCount ? '0' : '1';

                foreach (var line in co2LinesCopy)
                {
                    if (line[i] != filter)
                    {
                        co2Lines.Remove(line);
                    }
                }
            }

            if (string.IsNullOrEmpty(co2Rate))
            {
                co2Rate = co2Lines.First();
            }

            var gamma = Convert.ToInt32(oxygenRate, 2);
            var epsilon = Convert.ToInt32(co2Rate, 2);

            Console.WriteLine($"Day 3, task 2: {gamma * epsilon}");
        }
    }
}