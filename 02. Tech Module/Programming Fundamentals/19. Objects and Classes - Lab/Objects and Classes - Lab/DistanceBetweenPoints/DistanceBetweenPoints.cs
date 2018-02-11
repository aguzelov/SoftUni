using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceBetweenPoints
{
    class DistanceBetweenPoints
    {
        static void Main(string[] args)
        {
            double[] point = Console.ReadLine()
                                      .Split(' ')
                                      .Select(double.Parse)
                                      .ToArray();

            Point left = new Point(point[0], point[1]);

            point = Console.ReadLine()
                                      .Split(' ')
                                      .Select(double.Parse)
                                      .ToArray();

            Point right = new Point(point[0], point[1]);

            Console.WriteLine(string.Format("{0:0.000}", Point.Distance(left, right)));
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

        public static double Distance(Point left, Point rigth)
        {
            double sideA = left.X - rigth.X;
            double sideB = left.Y - rigth.Y;

            double distance = Math.Sqrt(Math.Pow(sideA, 2)+ Math.Pow(sideB, 2));

            return distance;
        }
    }
}
