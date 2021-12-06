using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC1._1.Y2021
{
    public class Day6Y2021
    {
        public static void Task1()
        {
            var lines = System.IO.File.ReadAllLines(@"C:\Coding\AdventOfCode\AOC1.1\Y2021\Data6.txt");
            var fishes = lines[0].Split(',').Select(int.Parse).ToList();

            for (int i = 0; i < 80; i++)
            {
                var newFishes = new List<int>();
                foreach (var fish in fishes)
                {
                    var olderFish = fish - 1;
                    if (olderFish < 0)
                    {
                        olderFish = 6;
                        newFishes.Add(8);
                    }

                    newFishes.Add(olderFish);
                }

                fishes = newFishes;
            }

            Console.WriteLine($"Day 6, task 1: {fishes.Count}");
        }

        public static void Task2()
        {
            var lines = System.IO.File.ReadAllLines(@"C:\Coding\AdventOfCode\AOC1.1\Y2021\Data6.txt");
            var fishes = lines[0].Split(',').Select(int.Parse).ToList();

            ulong sum = 0;

            var noBuenoDictionary = new Dictionary<(int days, int fishe, bool isReallyGoodFishy), ulong>();

            foreach (var fishe in fishes)
            {
                sum += BigBadCount(256, fishe, true, noBuenoDictionary);
            }

            Console.WriteLine($"Day 6, task 2: {sum}");
        }

        private static ulong BigBadCount(int days, int fishe, bool isReallyGoodFishy, Dictionary<(int days, int fishe, bool isReallyGoodFishy), ulong> noBuenoDictionary)
        {
            var randomTuple = (days, fishe, isReallyGoodFishy);
            if (noBuenoDictionary.ContainsKey(randomTuple))
            {
                return noBuenoDictionary[randomTuple];
            }

            ulong fishesCount = isReallyGoodFishy ? (ulong)1 : (ulong)0;
            if (days < fishe + 1)
            {
                return fishesCount;
            }

            var newDays = days - fishe - 1;
            var total = (fishesCount + BigBadCount(newDays, 6, true, noBuenoDictionary) + BigBadCount(newDays, 8, false, noBuenoDictionary));

            noBuenoDictionary[randomTuple] = total;

            return total;
        }
    }
}