using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.NumbersInReversedOrder
{
    class NumbersInReversedOrder
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            char[] array = number.ToCharArray();
            Array.Reverse(array);
            string reversedNumber = new String(array);
            Console.WriteLine(reversedNumber);
        }
    }
}
