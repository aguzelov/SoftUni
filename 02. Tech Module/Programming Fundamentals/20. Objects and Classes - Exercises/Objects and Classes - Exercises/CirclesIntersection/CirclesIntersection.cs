using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirclesIntersection
{
    class CirclesIntersection
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine()
                                    .Split(' ')
                                    .Select(double.Parse)
                                    .ToArray();

            Circle first = new Circle(input);

            input = Console.ReadLine()
                                    .Split(' ')
                                    .Select(double.Parse)
                                    .ToArray();

            Circle second = new Circle(input);

            Console.WriteLine(Circle.IsIntersect(first, second) ? "Yes" : "No");

        }
    }

    class Circle
    {
        private Point center;
        private double radius;

        public Circle(double[] input)
        {
            try
            {
                center = new Point(input[0], input[1]);
                this.radius = input[2];
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
            }

        }

        public double Radius { get => radius; set => radius = value; }
        internal Point Center { get => center; set => center = value; }

        public static bool IsIntersect(Circle first, Circle second)
        {
            double distance = Point.Distance(first.center, second.center);

            return distance <= first.Radius + second.Radius;
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

        public static double Distance(Point first, Point second)
        {
            return Math.Sqrt(Math.Pow(second.X - first.X, 2) + Math.Pow(second.Y - first.Y, 2));
        }
    }
}
