using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Comparing_floats
{
    class ComparingFloats
    {
        static void Main(string[] args)
        {
            double eps = 0.000001;

            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            if (Math.Abs(a - b) <= eps)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
