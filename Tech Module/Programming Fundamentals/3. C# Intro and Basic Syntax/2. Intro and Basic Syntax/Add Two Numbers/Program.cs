using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_Two_Numbers
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int firstNumber =int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            Console.WriteLine($"{firstNumber} + {secondNumber} = {firstNumber+secondNumber}");
        }

        
    }
}
