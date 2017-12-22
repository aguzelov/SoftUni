using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.RoundingNumbers
{
    class RoundingNumbers
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').Select(p => p.Trim()).Where(p => !string.IsNullOrWhiteSpace(p)).ToArray();

            double[] roundedArray = Array.ConvertAll(input, s => double.Parse(s));

            foreach(double d in roundedArray)
            {
                Console.WriteLine($"{d} => {Math.Round(d, MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
