using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _13.Factorial
{
    class Factorial
    {
        static BigInteger FactorialCal(int n)
        {
            if(n >= 2)
            {
                return n * FactorialCal(n - 1);
            }
            return 1;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(FactorialCal(n));
            
        }
    }
}
