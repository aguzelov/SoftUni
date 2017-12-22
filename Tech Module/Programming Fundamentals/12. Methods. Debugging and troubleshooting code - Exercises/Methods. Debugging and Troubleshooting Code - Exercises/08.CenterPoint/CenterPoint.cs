using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CenterPoint
{
    class CenterPoint
    {

        static Point ClosestPointToCenter(Point firstPoint, Point secondPoint)
        {
            Point center = new Point(0, 0);
            double firstPointDistance = Math.Sqrt((Math.Pow(firstPoint.X - center.X, 2) + Math.Pow(firstPoint.Y - center.Y, 2)));
            double secondPointDistance = Math.Sqrt((Math.Pow(secondPoint.X - center.X, 2) + Math.Pow(secondPoint.Y - center.Y, 2)));

            return firstPointDistance <= secondPointDistance ? firstPoint : secondPoint;
        }

        static void Main(string[] args)
        {
            Point firstPoint = new Point(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            Point secondPoint= new Point(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));


            Console.WriteLine(ClosestPointToCenter(firstPoint,secondPoint).GetPrintPoint());

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
