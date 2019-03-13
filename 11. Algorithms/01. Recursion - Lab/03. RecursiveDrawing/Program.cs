using System;

namespace _03._RecursiveDrawing
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());

            Drow(input);
        }

        private static void Drow(int n)
        {
            Console.WriteLine(new string('*', n));

            if (n == 1)
            {
                Console.WriteLine(new string('#', n));
                return;
            }
            Drow(n - 1);
            Console.WriteLine(new string('#', n));
        }
    }
}