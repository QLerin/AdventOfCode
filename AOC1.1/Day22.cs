using System;
using System.Collections.Generic;

namespace AOC1._1
{
    public class Day22
    {
        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data22.txt");

            var firstDeck = true;

            var deck1 = new Queue<int>();
            var deck2 = new Queue<int>();
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

        public static void Task2()
        {

        }
    }
}
