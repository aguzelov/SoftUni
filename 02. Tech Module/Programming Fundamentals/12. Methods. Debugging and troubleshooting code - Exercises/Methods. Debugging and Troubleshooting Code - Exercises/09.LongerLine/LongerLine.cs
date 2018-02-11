using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.LongerLine
{
    class LongerLine
    {
        static double Distance(Point firstPoint, Point secondPoint)
        {
            return Math.Sqrt((Math.Pow(firstPoint.X - secondPoint.X, 2) + Math.Pow(firstPoint.Y - secondPoint.Y, 2)));
        }

        static Point ClosestPointToCenter(Point firstPoint, Point secondPoint)
        {
            Point center = new Point(0, 0);
            double firstPointDistance = Distance(firstPoint, center);
            double secondPointDistance = Distance(secondPoint, center);

            return firstPointDistance <= secondPointDistance ? firstPoint : secondPoint;
        }

        static void Main(string[] args)
        {
            Point firstPoint = new Point(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            Point secondPoint = new Point(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            Point thirdPoint = new Point(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            Point fourthPoint = new Point(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));

            double firstLine = Distance(firstPoint, secondPoint);
            double secondLine = Distance(thirdPoint, fourthPoint);

            if(firstLine > secondLine)
            {
                Console.WriteLine(ClosestPointToCenter(firstPoint, secondPoint) == firstPoint ?
                                (firstPoint.GetPrintPoint() + secondPoint.GetPrintPoint()) :
                                (secondPoint.GetPrintPoint() + firstPoint.GetPrintPoint()));
            }
            else
            {
                Console.WriteLine(ClosestPointToCenter(thirdPoint, fourthPoint) == thirdPoint ?
                                (thirdPoint.GetPrintPoint() + fourthPoint.GetPrintPoint()) :
                                (fourthPoint.GetPrintPoint() + thirdPoint.GetPrintPoint()));
            }
            
            

        }
    }
    class Point
    {
        private double x;
        private double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        public string GetPrintPoint()
        {
            return $"({this.x}, {this.y})";
        }
    }
}
