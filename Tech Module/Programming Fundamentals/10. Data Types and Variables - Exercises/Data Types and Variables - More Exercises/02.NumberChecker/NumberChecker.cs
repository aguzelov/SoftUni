using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.NumberChecker
{
    class NumberChecker
    {
        static void Main(string[] args)
        {
            
            string userInput = Console.ReadLine();
            if (long.TryParse(userInput, out long intValue))
            {
                Console.WriteLine("integer");
            }else if(double.TryParse(userInput, out double doubleValue))
            {
                Console.WriteLine("floating-point");
            }
        }
    }
}
