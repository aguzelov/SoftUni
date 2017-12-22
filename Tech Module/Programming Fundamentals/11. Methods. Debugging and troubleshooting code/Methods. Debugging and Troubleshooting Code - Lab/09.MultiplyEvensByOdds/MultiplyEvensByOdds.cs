using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.MultiplyEvensByOdds
{
    class MultiplyEvensByOdds
    {
        static int evenSum;
        static int oddSum;

        static void AddToEvenSum(int number)
        {
             while(number > 0)
            {
                int lastDigit = number % 10;
                if(lastDigit%2 != 0)
                {
                    evenSum += lastDigit;
                }
                number /= 10;
            }
        }
        static void AddToOddSum(int number)
        {
            while (number > 0)
            {
                int lastDigit = number % 10;
                if (lastDigit % 2 == 0)
                {
                    oddSum += lastDigit;
                }
                number /= 10;
            }
        }
        static int GetMultipleOfEvensAndOdds(int number)
        {
            AddToEvenSum(number);
            AddToOddSum(number);
            return evenSum* oddSum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetMultipleOfEvensAndOdds(Math.Abs(int.Parse(Console.ReadLine()))));
        }
    }
}
