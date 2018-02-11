using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Practice_Integers
{
    class PracticeIntegers
    {
        static void Main(string[] args)
        {
            sbyte num1 = sbyte.Parse(Console.ReadLine());
            byte num2 = byte.Parse(Console.ReadLine());
            short num3 = short.Parse(Console.ReadLine());
            ushort num4 = ushort.Parse(Console.ReadLine());
            uint num5 = uint.Parse(Console.ReadLine());
            int num6 = int.Parse(Console.ReadLine());
            long num7 = long.Parse(Console.ReadLine());

            Console.WriteLine($"{num1}{System.Environment.NewLine}" +
                $"{num2}{System.Environment.NewLine}" +
                $"{num3}{System.Environment.NewLine}" +
                $"{num4}{System.Environment.NewLine}" +
                $"{num5}{System.Environment.NewLine}" +
                $"{num6}{System.Environment.NewLine}" +
                $"{num7}{System.Environment.NewLine}");
        }
    }
}
