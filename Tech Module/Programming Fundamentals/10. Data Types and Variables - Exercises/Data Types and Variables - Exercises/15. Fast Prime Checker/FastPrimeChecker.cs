using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Fast_Prime_Checker
{
    class FastPrimeChecker
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            for (int number = 2; number <= input; number++)
            {
                bool isPrime = true;
                for (int j = 2; j <= Math.Sqrt(number); j++)
                {
                    if (number % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{number} -> {isPrime}");
            }
        }
    }
}
