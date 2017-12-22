using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ConvertFromBase_NToBase_10
{
    class ConvertFromBase_NToBase_10
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                                    .Split(' ')
                                    .ToArray();


            int n = int.Parse(input[0]);
            BigInteger number = BigInteger.Parse(input[1]);

            BigInteger result = new BigInteger(0);
            int lastDigit = 0;
            int pow = 0;
            if (n >= 2 && n <= 10)
            {
                while (number > 0)
                {
                    lastDigit = int.Parse(number.ToString().Last().ToString());

                    number /= 10;

                    result += BigInteger.Multiply(lastDigit, BigInteger.Pow(n, pow));

                    pow++;
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
