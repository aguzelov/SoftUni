using System;
using System.Linq;

namespace _04._Generating0_1Vectors
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var vector = new int[n];
            var index = 0;

            Get01(vector, index);
        }

        private static void Get01(int[] vector, int index)
        {
            if (index > vector.Length - 1)
            {
                Console.WriteLine(string.Join("", vector));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                Get01(vector, index + 1);
            }
        }
    }
}