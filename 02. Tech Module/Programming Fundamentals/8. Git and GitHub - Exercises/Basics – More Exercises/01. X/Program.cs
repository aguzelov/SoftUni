using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.X
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < (n-1)/2; i++)
            {
                print(replaceString(" ", i));
                print("x");
                print(replaceString(" ", (n-2)-i*2));
                print("x");
                printLine(replaceString(" ", i));
            }

            print(replaceString(" ", (n - 1) / 2));
            print("x");
            printLine(replaceString(" ", (n - 1) / 2));


            for (int i = (n-2) / 2; i >= 0; i--)
            {
                print(replaceString(" ", i));
                print("x");
                print(replaceString(" ", (n - 2) - i * 2));
                print("x");
                printLine(replaceString(" ", i));
            }

        }
        static void print(string text)
        {
            Console.Write(text);
        }
        static void printLine(string text)
        {
            Console.WriteLine(text);
        }
        static string replaceString(string symbol, int count)
        {
            string text = "";
            for(int i = 0; i < count; i++)
            {
                text += symbol;
            }
            return text;
        }
    }
}
