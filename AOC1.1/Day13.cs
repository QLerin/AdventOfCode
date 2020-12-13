using System;
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

            var minValue = waitTimes.Min(waitTime => waitTime.Item2);
            Console.WriteLine($"Day 13, task 1: {waitTimes[6].Item2 * waitTimes[6].bus}");
        }

        public static void Task2()
        {

        }
    }
}
