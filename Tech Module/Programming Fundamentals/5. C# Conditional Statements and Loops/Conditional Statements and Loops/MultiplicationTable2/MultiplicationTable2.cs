using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicationTable2
{
    class MultiplicationTable2
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int startNumber = int.Parse(Console.ReadLine());

            bool isGreaterThan10 = true;

            for(int i = startNumber; i <= 10; i++)
            {
                isGreaterThan10 = false;
                Console.WriteLine($"{firstNumber} X {i} = {firstNumber*i}");
            }
            if (isGreaterThan10)
            {
                Console.WriteLine($"{firstNumber} X {startNumber} = {firstNumber * startNumber}");
            }
        }
    }
}
