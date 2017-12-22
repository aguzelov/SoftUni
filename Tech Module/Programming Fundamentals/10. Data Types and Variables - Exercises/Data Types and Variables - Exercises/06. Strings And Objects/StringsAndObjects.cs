using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Strings_And_Objects
{
    class StringsAndObjects
    {
        static void Main(string[] args)
        {
            string firstString = Console.ReadLine();
            string secondString = Console.ReadLine();

            object obj = firstString + " " + secondString;

            string thirdString = (string)obj;

            Console.WriteLine(thirdString);
        }
    }
}
