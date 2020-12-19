using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC1._1
{
    public class Day19_2
    {
        private class Filter
        {
            public Filter()
            {
                UsedFilters = new List<List<Filter>>();
                RegexPart = "";
            }

            //Only used two times for "a" and "b" but w/e
            public List<List<Filter>> UsedFilters { get; }

            public string RegexPart { get; set; }
        }

        public static void Task2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data19_2.txt");

            var isFilters = true;
            var usedFilters = new Dictionary<int, Filter>();
            var messages = new List<string>();

            foreach (var line in lines)
            {
                if (line == "")
                {
                    isFilters = false;
                    continue;
                }

                if (isFilters)
                {
                    AddFilter(line, usedFilters);
                }
                else
                {
                    messages.Add(line);
                }
            }

            var regexSadness42 = GetRegexSadness(usedFilters[42]);
            var regexSadness31 = GetRegexSadness(usedFilters[31]);
            var count = 0;

            foreach (var message in messages)
            {
                if (DoesMessageMatches(message, regexSadness42, regexSadness31))
                {
                    count++;
                }
            }

            //var count = messages.Count(message => Regex.IsMatch(message, regexSadness));
            Console.WriteLine($"Day 19, task 2: {count}");
        }

        private static bool DoesMessageMatches(string message, string regexSadness42, string regexSadness31)
        {
            string recombined = "";
            var messageToMatch = message;
            var matches42 = Regex.Matches(messageToMatch, regexSadness42).Select(match => match.Value).ToList();
            var usedCount = 0;
            if (matches42.Count > 0)
            {
                foreach (var match in matches42)
                {
                    if (messageToMatch.StartsWith(match))
                    {
                        messageToMatch = messageToMatch.Substring(match.Length);
                        recombined += match;
                        usedCount++;
                    }
                    else
                    {
                        if (usedCount < 2)
                        {
                            return false;
                        }

                        break;
                    }
                }
            }

            var matches31 = Regex.Matches(messageToMatch, regexSadness31).Select(match => match.Value).ToList();
            if (matches31.Count == 0 || matches31.Count > usedCount - 1)
            {
                return false;
            }

            recombined += string.Join("", matches31);

            return recombined == message;
        }

        private static void AddFilter(string line, Dictionary<int, Filter> usedFilters)
        {
            var nameWithUsedFilters = line.Split(":");
            var name = int.Parse(nameWithUsedFilters[0]);
            var filter = GetFilter(usedFilters, name);

            var secondPart = nameWithUsedFilters[1].Substring(1);

            if (secondPart.Contains("a"))
            {
                filter.RegexPart = "a";
                return;
            }

            if (secondPart.Contains("b"))
            {
                filter.RegexPart = "b";
                return;
            }

            var containingFiltersParts = secondPart.Split("|");
            foreach (var containingFiltersPart in containingFiltersParts)
            {
                var filters = containingFiltersPart.Split(" ").Where(split => split != "")
                    .Select(filterName => GetFilter(usedFilters, int.Parse(filterName))).ToList();
                filter.UsedFilters.Add(filters);
            }
        }

        private static Filter GetFilter(Dictionary<int, Filter> usedFilters, int name)
        {
            if (usedFilters.ContainsKey(name))
            {
                return usedFilters[name];
            }

            var filter = new Filter();
            usedFilters.Add(name, filter);

            return filter;
        }

        private static string GetRegexSadness(Filter filter)
        {
            if (filter.RegexPart != "")
            {
                return filter.RegexPart;
            }

            var filtersGroup = new List<string>();
            foreach (var filterList in filter.UsedFilters)
            {
                var filtersRegex = new List<string>();
                foreach (var usedFilter in filterList)
                {
                    filtersRegex.Add(GetRegexSadness(usedFilter));
                }

                filtersGroup.Add("(" + string.Join("", filtersRegex) + ")");
            }

            return "(" + string.Join('|', filtersGroup) + ")";
        }
    }
}