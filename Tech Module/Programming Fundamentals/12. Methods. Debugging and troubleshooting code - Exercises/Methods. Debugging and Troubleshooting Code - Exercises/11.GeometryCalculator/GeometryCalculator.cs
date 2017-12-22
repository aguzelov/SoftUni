using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.GeometryCalculator
{
    class GeometryCalculator
    {
        static void TriangleArea()
        {
            double side = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine(String.Format("{0:0.00}", .5 * side * height));
        }

        static void SquareArea()
        {
            double side = double.Parse(Console.ReadLine());
            Console.WriteLine(String.Format("{0:0.00}", Math.Pow(side, 2)));
        }

        static void RectangleArea()
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine(String.Format("{0:0.00}", width * height));
        }

        static void CircleArea()
        {
            double radius = double.Parse(Console.ReadLine());
            Console.WriteLine(String.Format("{0:0.00}", Math.PI * Math.Pow(radius, 2)));
        }

        static void Main(string[] args)
        {
            string figureType = Console.ReadLine(); // triangle, square, rectangle and circle

            switch (figureType)
            {
                case "triangle":
                    TriangleArea();
                    break;
                case "square":
                    SquareArea();
                    break;
                case "rectangle":
                    RectangleArea();
                    break;
                case "circle":
                    CircleArea();
                    break;
            }
        }
    }
}
