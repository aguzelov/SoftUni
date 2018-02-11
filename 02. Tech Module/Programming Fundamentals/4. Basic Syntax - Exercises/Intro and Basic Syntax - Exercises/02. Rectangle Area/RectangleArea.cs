using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Rectangle_Area
{
    class RectangleArea
    {
        static double width;
        static double height;
        RectangleArea(double w, double h)
        {
            width = w;
            height = h;
        }
        static void printArea()
        {
            Console.WriteLine(String.Format("{0:0.00}", width*height));
        }
        static void Main(string[] args)
        {
            RectangleArea rect = new RectangleArea(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            printArea();
        }
    }
}
