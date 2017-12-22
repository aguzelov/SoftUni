using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.ExtractMiddleElements
{
    class ExtractMiddleElements
    {
        static void Main(string[] args)
        {
            int[] array = Array.ConvertAll(
                                Console.ReadLine()
                                .Split(' ')
                                .Select(p => p.Trim())
                                .Where(p => !string.IsNullOrWhiteSpace(p))
                                .ToArray()
                                , p => int.Parse(p));

            int n = array.Length;
            if (n == 1)
            {
                Console.WriteLine($"{{ {array[0]} }}");
                return;
            }

            Console.WriteLine((n % 2 == 0) ?
                              $"{{ {array[n / 2 - 1]}, {array[n / 2]} }}" :
                              $"{{ {array[n / 2 - 1]}, {array[n / 2]}, {array[n / 2 + 1]} }}");
        }
    }
}
