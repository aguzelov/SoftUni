using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.MasterNumber
{
    class MasterNumber
    {

        static bool HaveOneEvenDigit(int number)
        {
            while(number > 0)
            {
                int lastDigit = number % 10;
                if(lastDigit%2 == 0)
                {
                    return true;
                }
                number /= 10;
            }
            return false;
        }

        static bool IsSumDivisibleBy7(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            if (sum % 7 == 0)
            {
                return true;
            }
            return false;
        }

        static bool IsSymmetric(int number)
        {
            if(number < 10)
            {
                return false;
            }

            string stringNumber =  number.ToString();
            int length = stringNumber.Length;

            for(int start = 0 ; start< length/2; start++)
            {
                if (stringNumber[start] != stringNumber[length-1 - (start)])
                {
                    return false;
                }
            }
            return true;
        }

        static bool IsMagic(int number)
        {
            return HaveOneEvenDigit(number) && IsSumDivisibleBy7(number) && IsSymmetric(number);
           
        }

        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());

            for(int i = 1; i <= endOfRange; i++)
            {
                if (IsMagic(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
