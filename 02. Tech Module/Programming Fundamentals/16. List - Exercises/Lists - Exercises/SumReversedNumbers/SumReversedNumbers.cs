using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumReversedNumbers
{
    class SumReversedNumbers
    {
        static string Reverse(string text)
        {
            char[] charArray = text.ToArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }


        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                            .Split(' ')
                            .Where(p => !string.IsNullOrWhiteSpace(p))
                            .ToList();

            decimal sum = 0;

            foreach(string elem in list)
            {
                sum += decimal.Parse(Reverse(elem));
            }

            Console.WriteLine(sum);
        }
    }
}
