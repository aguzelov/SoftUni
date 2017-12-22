using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.DrawAFilledSquare
{
    class DrawAFilledSquare
    {

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintLine("-", n * 2);
            Console.WriteLine();

            for (int i = 1; i <= n-2; i++)
            {
                PrintLine("-", 1);
                PrintLine("\\/", n - 1);
                PrintLine("-", 1);
                Console.WriteLine();
            }

            PrintLine("-", n * 2);
            Console.WriteLine();
        }
        static void PrintLine(string symbol, int count)
        {
            string line = "";
            for (int i = 0; i < count; i++)
            {
                line += symbol;
            }
            Console.Write(line);
        }
    }
}
