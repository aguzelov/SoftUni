using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.MaxMethod
{
    class MaxMethod
    {
        static int GetMax(int firstNumber, int secondNumber)
        {
            return Math.Max(firstNumber, secondNumber);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(GetMax(GetMax(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())), int.Parse(Console.ReadLine())));
        }
    }
}
