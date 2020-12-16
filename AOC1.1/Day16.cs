using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC1._1
{
    public class Day16
    {
        private class Filter
        {
            public Filter(string name, int firstStart, int firstEnd, int secondStart, int secondEnd)
            {
                Name = name;
                FirstStart = firstStart;
                FirstEnd = firstEnd;
                SecondStart = secondStart;
                SecondEnd = secondEnd;
            }

            public string Name { get; }
            public int FirstStart { get; }
            public int FirstEnd { get; }
            public int SecondStart { get; }
            public int SecondEnd { get; }

            public bool IsInRange(int number)
            {
                return number >= FirstStart && number <= FirstEnd || number >= SecondStart && number <= SecondEnd;
            }
        }

        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data16.txt");

            var filters = new List<Filter>();
            var nearbyTickets = new List<List<int>>();
            var yourTicket = ParseData(lines, filters, nearbyTickets);

            var sumRate = nearbyTickets.Sum(ticket =>
                ticket.Sum(ticketNumber =>
                    filters.Any(filter => 
                        filter.IsInRange(ticketNumber)) ? 0 : ticketNumber));

            Console.WriteLine($"Day 16, task 1: {sumRate}");
        }

        private static List<int> ParseData(string[] lines, List<Filter> filters, List<List<int>> nearbyTickets)
        {
            List<int> yourTicket = null;
            int spaces = 0;

            foreach (var line in lines)
            {
                if (line == "")
                {
                    spaces++;
                    continue;
                }

                switch (spaces)
                {
                    case 0:
                        var nameWithNumbers = line.Split(":");
                        var name = nameWithNumbers[0];
                        var numbers = nameWithNumbers[1].Split(" ");
                        var firstNumbers = numbers[1].Split('-');
                        var secondNumbers = numbers[3].Split('-');

                        filters.Add(new Filter(name, int.Parse(firstNumbers[0]), int.Parse(firstNumbers[1]), int.Parse(secondNumbers[0]), int.Parse(secondNumbers[1])));

                        break;

                    case 1:
                        if (line.StartsWith("your ticket:"))
                        {
                            continue;
                        }

                        yourTicket = line.Split(',').Select(number => int.Parse(number)).ToList();
                        break;

                    case 2:
                        if (line.StartsWith("nearby tickets:"))
                        {
                            continue;
                        }

                        nearbyTickets.Add(line.Split(',').Select(number => int.Parse(number)).ToList());
                        break;
                }
            }

            return yourTicket;
        }

        public static void Task2()
        {
        }
    }
}