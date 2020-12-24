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
            var withoutAllergens = GetWithoutAllergens(lines, allergensWithPossibilities);

            Console.WriteLine($"Day 21, task 1: {withoutAllergens.Count}");
        }

        private static List<string> GetWithoutAllergens(string[] lines, List<AllergenWithPossibilities> allergensWithPossibilities)
        {
            var allPossibilities = new List<string>();

            foreach (var line in lines)
            {
                var parts = line.Split(" (contains ");
                var possibilities = parts[0].Split(" ");
                allPossibilities.AddRange(possibilities);
                var allergens = parts[1].Substring(0, parts[1].Length - 1).Split(", ");
                allergensWithPossibilities.AddRange(allergens.Select(allergen =>
                    new AllergenWithPossibilities(allergen, possibilities.ToHashSet())));
            }

            var groupedAllergens = allergensWithPossibilities.GroupBy(allergen => allergen.Name);
            foreach (var grouped in groupedAllergens)
            {
                var inEveryGroup = allPossibilities.Distinct()
                    .Where(possibility => grouped.All(group => @group.Possibilities.Contains(possibility)));
                allPossibilities.RemoveAll(possibility => inEveryGroup.Contains(possibility));
            }

            return allPossibilities;
        }

        public static void Task2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data21.txt");
            var allergens = GetAllergensList(lines).ToHashSet();

            var allergensWithPossibilities = new List<AllergenWithPossibilities>();
            
            var groupedAllergens = allergens.GroupBy(allergen => allergen.Name);
            foreach (var grouped in groupedAllergens)
            {
                var possibilities = grouped.SelectMany(group => group.Possibilities).ToHashSet();
                possibilities = possibilities.Where(possibility => grouped.All(group => group.Possibilities.Contains(possibility))).ToHashSet();
                allergensWithPossibilities.Add(new AllergenWithPossibilities(grouped.Key, possibilities));
            }

            var tuples = new List<(string name, string otherName)>();
            while (true)
            {
                var onePossibility = allergensWithPossibilities.FirstOrDefault(allergen => allergen.Possibilities.Count == 1);
                if (onePossibility == null)
                {
                    break;
                }
                tuples.Add((onePossibility.Name, onePossibility.Possibilities.First()));
                allergensWithPossibilities.Remove(onePossibility);
                allergensWithPossibilities.ForEach(allergen => allergen.Possibilities.Remove(onePossibility.Possibilities.First()));
            }

            var result = string.Join(',', tuples.OrderBy(tuple => tuple.name).Select(tuple => tuple.otherName));
            Console.WriteLine($"Day 21, task 2: {result}");
        }

        private static List<AllergenWithPossibilities> GetAllergensList(string[] lines)
        {
            var allergensList = new List<AllergenWithPossibilities>();

            foreach (var line in lines)
            {
                var parts = line.Split(" (contains ");
                var possibilities = parts[0].Split(" ");
                var allergens = parts[1].Substring(0, parts[1].Length - 1).Split(", ");
                allergensList.AddRange(allergens.Select(allergen => new AllergenWithPossibilities(allergen, possibilities.ToHashSet())));
            }

            return allergensList;
        }
    }
}