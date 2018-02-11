using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfOddNumbers
{
    class SumOfOddNumbers
    {
        static int sum = 0;

        static void add(int number)
        {
            sum += number;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int number = 1;

            while (n != 0)
            {
                if(number%2 != 0)
                {
                    Console.WriteLine(number);
                    add(number);
                    n--;
                }
                number++;
                
            }
            Console.WriteLine("Sum: " + sum);
        }
    }
}
