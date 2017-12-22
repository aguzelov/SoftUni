using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisibleBy3
{
    class DivisibleBy3
    {
        static void Main(string[] args)
        {
            int number = 1;
            while (number != 100)
            {
                if(number%3 == 0)
                {
                    Console.WriteLine(number);
                }
                number++;
            }
        }
    }
}
