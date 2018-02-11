using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FibonacciNumbers
{
    class FibonacciNumbers
    {
        static int Fib(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            else
            {
                return Fib(n - 2) + Fib(n - 1);
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Fib(n));

        }
    }
}
