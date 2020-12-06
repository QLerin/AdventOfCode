using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC1._1
{
    public class Day6
    {
        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data6.txt");
            var groups = GetGroups(lines);

            int count = 0;
            foreach (var group in groups)
            {
                var groupChars = new HashSet<char>();
                foreach (var person in group)
                {
                    foreach (var answer in person)
                    {
                        groupChars.Add(answer);
                    }
                }
                count += groupChars.Count;
            }

            Console.WriteLine($"Day 6, task 1: {count}");
        }

        public static void Task2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data6.txt");
            var groups = GetGroups(lines);

            int count = 0;
            foreach (var group in groups)
            {
                var peopleCount = group.Count;

                var groupChars = new Dictionary<char, int>();
                foreach (var person in group)
                {
                    foreach (var answer in person)
                    {
                        if (groupChars.ContainsKey(answer))
                        {
                            groupChars[answer]++;
                        }
                        else
                        {
                            groupChars[answer] = 1;
                        }
                    }
                }

                count += groupChars.Where(keyValue => keyValue.Value == peopleCount).Count();
            }

            Console.WriteLine($"Day 6, task 2: {count}");
        }

        private static List<List<string>> GetGroups(string[] lines)
        {
            var groups = new List<List<string>>();

            var group = new List<string>();
            foreach (var line in lines)
            {
                if (line == "")
                {
                    groups.Add(group);
                    group = new List<string>();
                    continue;
                }

                group.Add(line);
            }

            groups.Add(group);
            return groups;
        }
    }
}