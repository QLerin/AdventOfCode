using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC1._1
{
    public class Day15
    {
        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data15.txt");
            var startingNumbers = lines.First().Split(',').Select(number => int.Parse(number)).ToList();

            var numbersCount = new Dictionary<int, int>();

            int currentNumber = 0;
            var usedNumbers = new List<int>();
            while (currentNumber < 2020)
            {
                if (currentNumber < startingNumbers.Count)
                {
                    var number = startingNumbers[currentNumber];
                    AddNumber(numbersCount, usedNumbers, number);
                }
                else
                {
                    var lastNumber = usedNumbers.Last();
                    if (numbersCount[lastNumber] == 1)
                    {
                        AddNumber(numbersCount, usedNumbers, 0);
                    }
                    else
                    {
                        var tempNumbers = usedNumbers.ToList();
                        tempNumbers.RemoveAt(tempNumbers.Count - 1);
                        var lastIndex = tempNumbers.FindLastIndex(number => number == lastNumber);
                        AddNumber(numbersCount, usedNumbers, currentNumber - 1 - lastIndex);
                    }
                }

                currentNumber++;
            }

            Console.WriteLine($"Day 15, task 1: {usedNumbers.Last()}");
        }

        private static void AddNumber(Dictionary<int, int> numbersCount, List<int> usedNumbers, int number)
        {
            usedNumbers.Add(number);
            if (numbersCount.ContainsKey(number))
            {
                numbersCount[number]++;
            }
            else
            {
                numbersCount[number] = 1;
            }
        }

        public static void Task2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data15.txt");
            var startingNumbers = lines.First().Split(',').Select(number => int.Parse(number)).ToList();

            var numbersCount = new Dictionary<int, int>();
            var lastUsed = new Dictionary<int, TwoNumbers>();

            int currentNumber = 0;
            var usedNumbers = new List<int>();

            while (currentNumber < 30000000)
            {
                if (currentNumber < startingNumbers.Count)
                {
                    var number = startingNumbers[currentNumber];
                    AddTrackedNumber(numbersCount, lastUsed, usedNumbers, number, currentNumber);
                }
                else
                {
                    var lastNumber = usedNumbers.Last();
                    if (numbersCount[lastNumber] == 1)
                    {
                        AddTrackedNumber(numbersCount, lastUsed, usedNumbers, 0, currentNumber);
                    }
                    else
                    {
                        var lastIndex = lastUsed[lastNumber].SecondIndex;
                        AddTrackedNumber(numbersCount, lastUsed, usedNumbers, currentNumber - 1 - lastIndex, currentNumber);
                    }
                }

                currentNumber++;
            }

            Console.WriteLine($"Day 15, task 2: {usedNumbers.Last()}");
        }

        private class TwoNumbers
        {
            public TwoNumbers(int firstIndex)
            {
                FirstIndex = firstIndex;
            }

            public int FirstIndex { set; get; }
            public int SecondIndex { set; get; }

            public void Add(int index)
            {
                SecondIndex = FirstIndex;
                FirstIndex = index;
            }
        }

        private static void AddTrackedNumber(Dictionary<int, int> numbersCount, Dictionary<int, TwoNumbers> lastUsed, List<int> usedNumbers, int number, int currentNumber)
        {
            usedNumbers.Add(number);
            if (numbersCount.ContainsKey(number))
            {
                lastUsed[number].Add(currentNumber);
                numbersCount[number]++;
            }
            else
            {
                lastUsed[number] = new TwoNumbers(currentNumber);
                numbersCount[number] = 1;
            }
        }
    }
}