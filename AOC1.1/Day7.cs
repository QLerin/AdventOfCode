using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC1._1
{
    public class Day7
    {
        private class Bag
        {
            public Bag(string name)
            {
                Name = name;
                Children = new Dictionary<Bag, int>();
            }

            public string Name { get; }
            public Dictionary<Bag, int> Children { get; } 
        }

        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data7.txt");
            Dictionary<string, Bag> dictionary = GetDictionary(lines);

            var bagsWhichCanCarry = new HashSet<Bag>
            {
                dictionary["shiny gold"]
            };

            foreach (var bag in dictionary.Values)
            {
                if (bagsWhichCanCarry.Contains(bag))
                {
                    continue;
                }

                foreach (var child in bag.Children.Keys)
                {
                    if (bagsWhichCanCarry.Contains(child))
                    {
                        bagsWhichCanCarry.Add(bag);
                    }

                    var chainSet = new HashSet<Bag> { bag, child };
                    RecursiveSearch(bagsWhichCanCarry, child, chainSet);
                }
            }

            Console.WriteLine($"Day 7, task 1: {bagsWhichCanCarry.Count - 1}");
            var texts = bagsWhichCanCarry.Select(bag => bag.Name).OrderBy(bag => bag).ToList();
        }

        public static void Task2()
        {

        }

        private static Dictionary<string, Bag> GetDictionary(string[] lines)
        {
            var dictionary = new Dictionary<string, Bag>();

            foreach (var line in lines)
            {
                var tempLine = line.Replace(" bags", "").Replace(" bag", "").Replace(".", "");
                var parentWithChildren = tempLine.Split(" contain ");
                var parentName = parentWithChildren[0];
                var parentBag = GetBag(dictionary, parentName);

                if (parentWithChildren[1].Contains("no other"))
                {
                    continue;
                }

                var childrenStrings = parentWithChildren[1].Split(", ");
                foreach (var childString in childrenStrings)
                {
                    var parts = childString.Split(" ");
                    int count = int.Parse(parts[0]);
                    string childName = $"{parts[1]} {parts[2]}";
                    var childBag = GetBag(dictionary, childName);
                    parentBag.Children.Add(childBag, count);
                }
            }

            return dictionary;
        }

        private static Bag GetBag(Dictionary<string, Bag> dictionary, string name)
        {
            Bag bag;

            if (dictionary.ContainsKey(name))
            {
                bag = dictionary[name];
            }
            else
            {
                bag = new Bag(name);
                dictionary[name] = bag;
            }

            return bag;
        }

        private static void RecursiveSearch(HashSet<Bag> bagsWhichCanCarry, Bag bag, HashSet<Bag> chainSet)
        {
            foreach (var child in bag.Children)
            {
                if (chainSet.Contains(child.Key))
                {
                    return;
                }

                if (bagsWhichCanCarry.Contains(child.Key))
                {
                    foreach (var chainBag in chainSet)
                    {
                        bagsWhichCanCarry.Add(chainBag);
                    }
                    return;
                }

                var currentChainSet = chainSet.ToHashSet();
                currentChainSet.Add(child.Key);

                foreach (var childChild in child.Key.Children)
                {
                    RecursiveSearch(bagsWhichCanCarry, childChild.Key, currentChainSet);
                }
            }
        }
    }
}
