using System;
using System.Linq;

namespace _01._RecursiveArraySum
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var arr = input.Split(' ').Select(int.Parse).ToArray();
            var index = 0;
            var sum = Sum(arr, index);

            Console.WriteLine(sum);
        }

        private static int Sum(int[] array, int index)
        {
            if (index >= array.Length)
            {
                return 0;
            }

            return array[index] + Sum(array, ++index);
        }
    }
}