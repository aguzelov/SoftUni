using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Megapixels
{
    class Megapixels
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("" + width + "x" + height + " => " + Math.Round((width * height) / 1000000.0, 1) + "MP");
        }
    }
}
