using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ConvertFromBase_10ToBase_N
{
    class ConvertFromBase_10ToBase_N
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                                    .Split(' ')
                                    .ToArray();

            BigInteger n = BigInteger.Parse(input[0]);
            BigInteger number = BigInteger.Parse(input[1]);

            string result = "";
            BigInteger rem = new BigInteger(0);

            if(n >= 2 && n<= 10)
            {
                while(number > 0)
                {
                    rem = number % n;
                    number /= n;
                    result = rem.ToString() + result;
                }
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
