using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC1._1
{
    public class Day18
    {
        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data18.txt");
            long sum = 0;
            foreach (var line in lines)
            {
                var function = line;
                while (function.Contains("("))
                {
                    var endingIndex = function.IndexOf(")");
                    var startingIndex = function.LastIndexOf("(", endingIndex, endingIndex + 1);
                    var temporaryFunction = function.Substring(startingIndex + 1, endingIndex - startingIndex - 1);
                    function = function.Substring(0, startingIndex) + SumWithoutParenthesis(temporaryFunction) + function.Substring(endingIndex + 1);
                }

                sum += SumWithoutParenthesis(function);
            }

            Console.WriteLine($"Day 18, task 1: {sum}");
        }

        private static long SumWithoutParenthesis(string function)
        {
            var groups = function.Split(" ");
            var result = long.Parse(groups[0]);
            for (var i = 1; i < groups.Length; i += 2)
            {
                var action = groups[i];
                var number = long.Parse(groups[i + 1]);
                if (action == "*")
                {
                    result *= number;
                }
                else
                {
                    result += number;
                }
            }

            return result;
        }

        public static void Task2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data18.txt");
            long sum = 0;
            foreach (var line in lines)
            {
                var function = line;
                while (function.Contains("("))
                {
                    var endingIndex = function.IndexOf(")");
                    var startingIndex = function.LastIndexOf("(", endingIndex, endingIndex + 1);
                    var temporaryFunction = function.Substring(startingIndex + 1, endingIndex - startingIndex - 1);
                    function = function.Substring(0, startingIndex) + SumWithoutParenthesisWithWeirdOrder(temporaryFunction) + function.Substring(endingIndex + 1);
                }

                sum += SumWithoutParenthesisWithWeirdOrder(function);
            }

            Console.WriteLine($"Day 18, task 2: {sum}");
        }

        private static long SumWithoutParenthesisWithWeirdOrder(string function)
        {
            var groups = function.Split(" ").ToList();
            while (groups.Contains("+"))
            {
                var plusIndex = GetPlusIndex(groups);
                var sum = long.Parse(groups[plusIndex - 1]) + long.Parse(groups[plusIndex + 1]);
                var newGroups = new List<string>();
                
                for (var i = 0; i < plusIndex - 1; i++)
                {
                    newGroups.Add(groups[i]);
                }
                
                newGroups.Add(sum.ToString());
                
                for (var i = plusIndex + 2; i < groups.Count; i++)
                {
                    newGroups.Add(groups[i]);
                }

                groups = newGroups;
            }

            var result = long.Parse(groups[0]);
            for (var i = 1; i < groups.Count; i += 2)
            {
                var number = long.Parse(groups[i + 1]);
                result *= number;
            }

            return result;
        }

        private static int GetPlusIndex(List<string> groups)
        {
            for (var i = 0; i < groups.Count; i++)
            {
                if (groups[i] == "+")
                {
                    return i;
                }
            }

            return int.MinValue;
        }
    }
}