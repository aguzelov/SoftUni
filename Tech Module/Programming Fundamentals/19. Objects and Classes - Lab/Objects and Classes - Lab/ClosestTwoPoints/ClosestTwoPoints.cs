using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestTwoPoints
{
    class ClosestTwoPoints
    {
        static List<Point> points = new List<Point>();

        static Dictionary<double, string> distance = new Dictionary<double, string> { };

        static void CalculateDistance()
        {
            for (int i = 0; i < points.Count - 1; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    Point left = points[i];
                    Point right = points[j];
                    double currDistance = Point.Distance(left, right);
                    if (!distance.ContainsKey(currDistance))
                    {
                        distance.Add(currDistance, $"({left.X}, {left.Y})\n({right.X}, {right.Y})");
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double[] point = Console.ReadLine()
                                        .Split(' ')
                                        .Select(double.Parse)
                                        .ToArray();

                points.Add(new Point(point[0], point[1]));
            }
            CalculateDistance();
            double minDistance = distance.Min(x => x.Key);
            Console.WriteLine(string.Format("{0:0.000}", minDistance));
            Console.WriteLine(distance[minDistance]);
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

            double distance = Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));

            return distance;
        }
    }
}
