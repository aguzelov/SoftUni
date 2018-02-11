using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.StringConcatenation
{
    class StringConcatenation
    {
        static void Main(string[] args)
        {
            char delimiter = char.Parse(Console.ReadLine());
            string evenOrOdd = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            string line = "";

            for (int i = 1; i <= n; i++)
            {
                string word = Console.ReadLine();
                if (evenOrOdd.Equals("even") && i % 2 == 0)
                {
                    line += word;
                    line += delimiter;
                }
                else if (evenOrOdd.Equals("odd") && i % 2 != 0)
                {
                    line += word;
                    line += delimiter;
                }
            }

            Console.WriteLine(line.Remove(line.Length - 1));
        }
    }
}
