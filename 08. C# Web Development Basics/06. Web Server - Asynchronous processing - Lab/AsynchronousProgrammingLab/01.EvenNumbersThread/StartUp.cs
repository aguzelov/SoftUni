using System;
using System.Linq;
using System.Threading;

namespace _01.EvenNumbersThread
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var rangeTokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var min = rangeTokens[0];
            var max = rangeTokens[1];

            Thread evens = new Thread(() => PrintEvenNumbers(min, max));
            evens.Start();
            evens.Join();
            Console.WriteLine("Thread finished work");
        }

        private static void PrintEvenNumbers(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}