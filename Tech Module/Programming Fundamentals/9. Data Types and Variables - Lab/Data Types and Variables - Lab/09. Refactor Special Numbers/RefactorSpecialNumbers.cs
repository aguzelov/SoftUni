using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Refactor_Special_Numbers
{
    class RefactorSpecialNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int currNumber = i;

                int sumOfDigit = 0;
                while (i > 0)
                {
                    sumOfDigit += i % 10;
                    i = i / 10;
                }
                bool isSpecial = (sumOfDigit == 5) || (sumOfDigit == 7) || (sumOfDigit == 11);
                Console.WriteLine($"{currNumber} -> {isSpecial}");
                sumOfDigit = 0;
                i = currNumber;
            }
        }
    }
}
