using System;
using System.Text;
using System.Numerics;

namespace _14.FactorialTrailingZeroes
{
    class FactorialTrailingZeroes
    {
        static BigInteger FactorialCal(int n)
        {
            if (n >= 2)
            {
                return n * FactorialCal(n - 1);
            }
            return 1;
        }
        static int TrailingZeroes(BigInteger number)
        {
            int zeroes = 0;
            string stringNumber = number.ToString();
            int length = stringNumber.Length;

            for (int i = length - 1; i > 0; i--)
            {
                if (stringNumber[i] == '0')
                {
                    zeroes++;
                }
                else
                {
                    return zeroes;
                }
            }
            return zeroes;
        }
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(TrailingZeroes(FactorialCal(number)));
        }
    }
}
