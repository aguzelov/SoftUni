using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Practice_Floating_Points
{
    class PracticeFloatingPoints
    {
        static void Main(string[] args)
        {

            decimal num1 = decimal.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            decimal num3 = decimal.Parse(Console.ReadLine());

            string newLine = System.Environment.NewLine;

            Console.WriteLine($"{num1}{newLine}" +
                $"{num2}{newLine}" +
                $"{num3}{newLine}");
        }
    }
}
