using System;
using System.Linq;

namespace _05._GeneratingCombinations
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var set = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var numberOfElements = int.Parse(Console.ReadLine());
            var vector = new int[numberOfElements];
            var index = 0;

            Generator(set, vector, index, index);
        }

        private static void Generator(int[] set, int[] vector, int index, int border)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (int i = border; i < set.Length; i++)
                {
                    vector[index] = set[i];
                    Generator(set, vector, index + 1, i + 1);
                }
            }
        }
    }
}