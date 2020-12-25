using System;

namespace AOC1._1
{
    public class Day25
    {
        public static void Task1()
        {
            var publicKey = 8252394;
            var publicKey2 = 6269621;

            var subjectNumber = 7;
            var loop = GetLoop(subjectNumber, publicKey);
            var loop2 = GetLoop(subjectNumber, publicKey2);

            long reminder = 1;
            for (int i = 0; i < loop2; i++)
            {
                reminder = reminder * publicKey % 20201227;
            }

            long reminder2 = 1;
            for (int i = 0; i < loop; i++)
            {
                reminder2 = reminder2 * publicKey2 % 20201227;
            }

            Console.WriteLine($"Day 25, task 1: {reminder}");
        }

        private static int GetLoop(int subjectNumber, int publicKey)
        {
            int loop = 1;
            var reminder = 7;
            while (true)
            {
                reminder = reminder * subjectNumber % 20201227;
                loop++;
                if (reminder == publicKey)
                {
                    break;
                }
            }

            return loop;
        }
    }
}