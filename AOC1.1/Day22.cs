using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC1._1
{
    public class Day22
    {
        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data22.txt");

            var deck1 = GetDecks(lines, out var deck2);

            while (deck1.Count > 0 && deck2.Count > 0)
            {
                var number1 = deck1.Dequeue();
                var number2 = deck2.Dequeue();

                if (number1 > number2)
                {
                    deck1.Enqueue(number1);
                    deck1.Enqueue(number2);
                }
                else
                {
                    deck2.Enqueue(number2);
                    deck2.Enqueue(number1);
                }
            }

            var result = 0;

            var deck = deck1.Count > deck2.Count ? deck1 : deck2;

            while (deck.Count > 0)
            {
                var count = deck.Count;
                result += count * deck.Dequeue();
            }

            Console.WriteLine($"Day 22, task 1: {result}");
        }

        private static Queue<int> GetDecks(string[] lines, out Queue<int> deck2)
        {
            var firstDeck = true;

            var deck1 = new Queue<int>();
            deck2 = new Queue<int>();
            foreach (var line in lines)
            {
                if (line.StartsWith("Player"))
                {
                    continue;
                }

                if (line == "")
                {
                    firstDeck = false;
                    continue;
                }

                var number = int.Parse(line);
                if (firstDeck)
                {
                    deck1.Enqueue(number);
                }
                else
                {
                    deck2.Enqueue(number);
                }
            }

            return deck1;
        }

        public static void Task2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data22.txt");

            var deck1 = GetDecks(lines, out var deck2);

            RecursiveCombat(deck1, deck2);

            var result = 0;

            var deck = deck1.Count > deck2.Count ? deck1 : deck2;

            while (deck.Count > 0)
            {
                var count = deck.Count;
                result += count * deck.Dequeue();
            }

            Console.WriteLine($"Day 22, task 2: {result}");
        }

        private static bool RecursiveCombat(Queue<int> deck1, Queue<int> deck2)
        {
            var usedCards = new HashSet<(string pastDeck1, string pastDeck2)>();
            while (deck1.Count > 0 && deck2.Count > 0)
            {
                var usedDeck1 = string.Join(",", deck1.ToList());
                var usedDeck2 = string.Join(",", deck2.ToList());
                if (usedCards.Contains((usedDeck1, usedDeck2)))
                {
                    return true;
                }

                usedCards.Add((usedDeck1, usedDeck2));
                
                var number1 = deck1.Dequeue();
                var number2 = deck2.Dequeue();

                bool firstWon;
                if (number1 <= deck1.Count && number2 <= deck2.Count)
                {
                    firstWon = RecursiveCombat(new Queue<int>(deck1.ToList().Take(number1)), new Queue<int>(deck2.ToList().Take(number2)));
                }
                else
                {
                    firstWon = number1 > number2;
                }

                if (firstWon)
                {
                    deck1.Enqueue(number1);
                    deck1.Enqueue(number2);
                }
                else
                {
                    deck2.Enqueue(number2);
                    deck2.Enqueue(number1);
                }
            }

            return deck1.Count > deck2.Count;
        }
    }
}