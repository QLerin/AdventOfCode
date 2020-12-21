using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC1._1
{
    public class Day21
    {
        public class AllergenWithPossibilities
        {
            public AllergenWithPossibilities(string name, HashSet<string> possibilities)
            {
                Name = name;
                Possibilities = possibilities;
            }

            public string Name { get; }
            public HashSet<string> Possibilities { get; }
        }

        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data21.txt");
            var allergensWithPossibilities = new List<AllergenWithPossibilities>();
            var allPossibilities = new List<string>();

            foreach (var line in lines)
            {
                var parts = line.Split(" (contains ");
                var possibilities = parts[0].Split(" ");
                allPossibilities.AddRange(possibilities);
                var allergens = parts[1].Substring(0, parts[1].Length - 1).Split(", ");
                allergensWithPossibilities.AddRange(allergens.Select(allergen => new AllergenWithPossibilities(allergen, possibilities.ToHashSet())));
            }

            var groupedAllergens = allergensWithPossibilities.GroupBy(allergen => allergen.Name);
            foreach (var grouped in groupedAllergens)
            {
                var inEveryGroup = allPossibilities.Distinct().Where(possibility => grouped.All(group => group.Possibilities.Contains(possibility)));
                allPossibilities.RemoveAll(possibility => inEveryGroup.Contains(possibility));
            }

            Console.WriteLine($"Day 21, task 1: {allPossibilities.Count}");
        }

        public static void Task2()
        {
        }
    }
}