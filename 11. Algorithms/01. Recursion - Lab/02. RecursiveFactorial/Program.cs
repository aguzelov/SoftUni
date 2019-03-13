using System;

namespace _02._RecursiveFactorial
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());

            var fact = FindFactorial(num);

            Console.WriteLine(fact);
        }

        private static long FindFactorial(int num)
        {
            if (num == 1)
            {
                return num;
            }

            return num * FindFactorial(num - 1);
        }
    }
}