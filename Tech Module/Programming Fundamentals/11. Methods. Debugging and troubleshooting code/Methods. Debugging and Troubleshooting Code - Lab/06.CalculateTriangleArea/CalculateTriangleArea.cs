using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.CalculateTriangleArea
{
    class CalculateTriangleArea
    {
        static double GetTriangleArea(double width, double height)
        {
            return width * height / 2;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(GetTriangleArea(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine())));
        }
    }
}
