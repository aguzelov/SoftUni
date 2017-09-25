using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Variable_in_Hex_Format
{
    class VariableInHexFormat
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine(), 16);
            Console.WriteLine(number);
        }
    }
}
