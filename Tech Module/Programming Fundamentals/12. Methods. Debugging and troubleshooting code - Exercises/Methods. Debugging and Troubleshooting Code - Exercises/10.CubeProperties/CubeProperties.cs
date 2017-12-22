using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.CubeProperties
{
    class CubeProperties
    {
        static double FaceDiagonal(double side)
        {
            return Math.Sqrt(2 * Math.Pow(side, 2));
        }
        static double SpaceDiagonal(double side)
        {
            return Math.Sqrt(3 * Math.Pow(side, 2));
        }
        static double Volume(double side)
        {
            return Math.Pow(side,3);
        }
        static double SurfaceArea(double side)
        {
            return 6 * Math.Pow(side, 2);
        }
        static void Main(string[] args)
        {
            double sideOfCube = double.Parse(Console.ReadLine());
            string parameter = Console.ReadLine();//face, space, volume or area

            switch (parameter)
            {
                case "face":
                    Console.WriteLine(String.Format("{0:0.00}",FaceDiagonal(sideOfCube)));
                    break;
                case "space":
                    Console.WriteLine(String.Format("{0:0.00}", SpaceDiagonal(sideOfCube)));
                    break;
                case "volume":
                    Console.WriteLine(String.Format("{0:0.00}", Volume(sideOfCube)));
                    break;
                case "area":
                    Console.WriteLine(String.Format("{0:0.00}", SurfaceArea(sideOfCube)));
                    break;
            }
        }
    }
}
