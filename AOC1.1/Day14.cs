using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC1._1
{
    public class Day14
    {
        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data14.txt");

            var currentDictionary = new Dictionary<int, string>();
            var currentMask = "";
            foreach (var line in lines)
            {
                if (line.StartsWith("mask"))
                {
                    currentMask = line.Substring(7);
                    continue;
                }

                var key = int.Parse(line.Split(']')[0].Substring(4));
                var value = int.Parse(line.Split(" ")[2]);
                var valueInBinary = Convert.ToString(value, 2).PadLeft(36, '0');

                string result = "";
                for (int i = 0; i < currentMask.Length; i++)
                {
                    if (currentMask[i] == 'X')
                    {
                        result += valueInBinary[i];
                        continue;
                    }

                    result += currentMask[i];
                }
                currentDictionary[key] = result;
            }

            ulong sum = GetSum(currentDictionary);

            Console.WriteLine($"Day 14, task 1: {sum}");
        }

        private static ulong GetSum(Dictionary<int, string> currentDictionary)
        {
            ulong sum = 0;
            foreach (var valueKey in currentDictionary)
            {
                sum += Convert.ToUInt64(valueKey.Value, 2);
            }

            return sum;
        }

        public static void Task2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data14.txt");

            var currentDictionary = new Dictionary<string, int>();
            var currentMask = "";
            foreach (var line in lines)
            {
                if (line.StartsWith("mask"))
                {
                    currentMask = line.Substring(7);
                    continue;
                }

                var value = int.Parse(line.Split(" ")[2]);
                var key = int.Parse(line.Split(']')[0].Substring(4));
                var keyInBinary = Convert.ToString(key, 2).PadLeft(36, '0');

                var xAmount = currentMask.Where(symbol => symbol == 'X').Count();
                var resultsCount = xAmount == 0 ? 1 : (int)Math.Pow(2, xAmount);

                var addresses = new List<List<char>>();

                for (int i = 0; i < resultsCount; i++)
                {
                    addresses.Add(new List<char>());
                }

                //Very proud and very ashamed at the same time
                var digitsCount = Convert.ToString(resultsCount - 1, 2).Length;
                var addressesXs = new List<string>();
                for (int i = 0; i < resultsCount; i++)
                {
                    addressesXs.Add(Convert.ToString(i, 2).PadLeft(digitsCount, '0'));
                }

                int xCount = 0;
                for (int i = 0; i < currentMask.Length; i++)
                {
                    switch (currentMask[i])
                    {
                        case 'X':
                            for (int y = 0; y < addresses.Count; y++)
                            {
                                addresses[y].Add(addressesXs[y][xCount]);
                            }

                            xCount++;
                            break;

                        case '0':
                            foreach (var address in addresses)
                            {
                                address.Add(keyInBinary[i]);
                            }
                            break;

                        case '1':
                            foreach (var address in addresses)
                            {
                                address.Add('1');
                            }
                            break;
                    }
                }

                foreach (var address in addresses.Select(chars => new string(chars.ToArray())))
                {
                    currentDictionary[address] = value;
                }
            }

            ulong sum = CountValues(currentDictionary);

            Console.WriteLine($"Day 14, task 2: {sum}");
        }

        private static ulong CountValues(Dictionary<string, int> currentDictionary)
        {
            ulong sum = 0;
            foreach (var value in currentDictionary.Values)
            {
                sum += (ulong)value;
            }

            return sum;
        }
    }
}