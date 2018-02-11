using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Miles_to_Kilometers
{
    class MilesToKilometers
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Format("{0:0.00}", (double.Parse(Console.ReadLine())*1.60934)));
        }
    }
}
