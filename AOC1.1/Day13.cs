using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC1._1
{
    public class Day13
    {
        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data13.txt");

            var earliestArival = int.Parse(lines[0]);
            var buses = lines[1].Split(",").Where(text => text != "x").Select(number => int.Parse(number)).ToList();
            var waitTimes = buses.Select(bus => (bus, bus - earliestArival % bus)).ToList();

            var minValue = waitTimes.OrderBy(waitTime => waitTime.Item2).First();

            Console.WriteLine($"Day 13, task 1: {minValue.Item2 * minValue.bus}");
        }

        public static void Task2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data13.txt");

            var splits = lines[1].Split(",");

            var busOffsets = new List<(int bus, int offset)>();
            for (int i = 0; i < splits.Length; i++)
            {
                if (splits[i] == "x")
                {
                    continue;
                }

                busOffsets.Add((int.Parse(splits[i]), i));
            }

            long startingNumber = busOffsets.First().bus;
            for (int i = 1; i < busOffsets.Count; i++)
            {
                long increase = 1;
                for (int j = 0; j < i; j++)
                {
                    increase *= busOffsets[j].bus;
                }

                startingNumber = GetWhenMatches(startingNumber, increase, busOffsets[i].bus, busOffsets[i].offset);
            }

            Console.WriteLine($"Day 13, task 2: {startingNumber}");
        }

        private static long GetWhenMatches(long startingNumber, long increase, int bus, int offset)
        {
            while (true)
            {
                if ((startingNumber + offset) % bus == 0)
                {
                    break;
                }

                startingNumber += increase;
            }

            return startingNumber;
        }
    }
}