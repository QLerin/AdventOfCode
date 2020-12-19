using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC1._1
{
    public class Day19
    {
        private class Filter
        {
            public Filter(int name)
            {
                Name = name;
                UsedFilters = new List<List<Filter>>();
                RegexPart = "";
            }

            public int Name { get; }
            public List<List<Filter>> UsedFilters { get; }
            public string RegexPart { get; set; }
        }

        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data19.txt");

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

            var filter = usedFilters[0];
            var regexSadness = $"^{GetRegexSadness(filter)}$";

            var count = messages.Count(message => Regex.IsMatch(message, regexSadness));
            Console.WriteLine($"Day 19, task 1: {count}");
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

            var filter = new Filter(name);
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

        public static void Task2()
        {
        }
    }
}