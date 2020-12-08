using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC1._1
{
    public class Day8
    {
        private class Instruction
        {
            public Instruction(string name, int value)
            {
                Name = name;
                Value = value;
            }

            public string Name { get; set; }
            public int Value { get; }
            public int TimeUsed { get; set; }
        }

        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data8.txt");

            List<Instruction> instructions = GetInstructions(lines);

            int acc = TraverseUntilLoop(instructions, out _);

            Console.WriteLine($"Day 8, task 1: {acc}");
        }

        public static void Task2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data8.txt");

            List<Instruction> instructions = GetInstructions(lines);

            for (int i = 0; i < instructions.Count; i++)
            {
                var clone = instructions.Select(instruction => new Instruction(instruction.Name, instruction.Value)).ToList();
                switch (clone[i].Name)
                {
                    case "nop":
                        clone[i].Name = "jmp";
                        break;

                    case "acc":
                        continue;

                    case "jmp":
                        clone[i].Name = "nop";
                        break;
                }

                int acc = TraverseUntilLoop(clone, out bool didFinish);
                if (didFinish)
                {
                    Console.WriteLine($"Day 8, task 2: {acc}");
                    return;
                }
            }
        }

        private static List<Instruction> GetInstructions(string[] lines)
        {
            var instructions = new List<Instruction>();
            foreach (var line in lines)
            {
                var instructionWithCount = line.Split(" ");
                instructions.Add(new Instruction(instructionWithCount[0], int.Parse(instructionWithCount[1])));
            }

            return instructions;
        }

        private static int TraverseUntilLoop(List<Instruction> instructions, out bool didFinish)
        {
            didFinish = false;
            int step = 1;
            int acc = 0;
            for (int i = 0; i < instructions.Count; i += step)
            {
                if (instructions[i].TimeUsed > 0)
                {
                    return acc;
                }

                switch (instructions[i].Name)
                {
                    case "nop":
                        step = 1;
                        break;

                    case "acc":
                        acc += instructions[i].Value;
                        step = 1;
                        break;

                    case "jmp":
                        step = instructions[i].Value;
                        break;
                }
                instructions[i].TimeUsed++;
            }

            didFinish = true;
            return acc;
        }
    }
}