using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passed
{
    class Passed
    {
        static void Main(string[] args)
        {
            if(double.Parse(Console.ReadLine()) >= 3.00)
            {
                Console.WriteLine("Passed!");
            }
        }
    }
}
