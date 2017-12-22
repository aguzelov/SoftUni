using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ReverseArrayOfStrings
{
    class ReverseArrayOfStrings
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(' ').Select(p => p.Trim()).Where(p => !string.IsNullOrWhiteSpace(p)).ToArray();
            Array.Reverse(array);
            foreach(string element in array)
            {
                Console.Write(element + " ");
            }
        }
    }
}
