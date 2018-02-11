using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Special_Numbers
{
    class SpecialNumbers
    {
        static int SumOfDigit(int num)
        {
            int lastDigit;
            int sum = 0;
            while(num != 0)
            {
                lastDigit = num % 10;
                sum += lastDigit;
                num = num / 10;
            }
            return sum;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                int sum = SumOfDigit(i);
                
                Console.WriteLine(sum == 5 || sum == 7 || sum == 11 ? $"{i} -> True" : $"{i} -> False");
            }
        }
    }
}
