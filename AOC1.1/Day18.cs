using System;

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
        }
    }
}