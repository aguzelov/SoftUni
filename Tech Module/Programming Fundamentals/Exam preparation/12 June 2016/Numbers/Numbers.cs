using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    class Numbers
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            double average = numbers.Average();

            numbers = numbers.Where(x => x > average).OrderByDescending(x => x).Take(5).ToList();

            if (numbers.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
