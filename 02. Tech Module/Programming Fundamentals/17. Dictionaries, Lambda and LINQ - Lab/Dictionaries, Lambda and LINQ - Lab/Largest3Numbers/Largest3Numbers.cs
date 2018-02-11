using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest3Numbers
{
    class Largest3Numbers
    {
        static void Main(string[] args)
        {
            List<double> input = Console.ReadLine()
                                 .Split(' ')
                                 .Select(double.Parse)
                                 .ToList();

            var largest3Ithem = input.OrderByDescending(x => x).Take(3);
            Console.WriteLine(string.Join(" ", largest3Ithem));
        }
    }
}
