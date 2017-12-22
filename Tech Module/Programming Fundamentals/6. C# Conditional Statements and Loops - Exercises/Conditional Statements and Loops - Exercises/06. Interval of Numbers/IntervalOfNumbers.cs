using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Interval_of_Numbers
{
    class IntervalOfNumbers
    {
        static void printInterval(int startNumber, int endNumber)
        {
            for (int i = startNumber; i <= endNumber; i++)
            {
                Console.WriteLine(i);
            }
        }

        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());
            if (startNumber < endNumber)
            {
                printInterval(startNumber, endNumber);
            }
            else
            {
                printInterval(endNumber, startNumber);
            }

        }
    }
}
