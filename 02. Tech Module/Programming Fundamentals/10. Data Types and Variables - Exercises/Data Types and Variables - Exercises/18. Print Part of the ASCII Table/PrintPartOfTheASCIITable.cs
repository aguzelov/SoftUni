using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.Print_Part_of_the_ASCII_Table
{
    class PrintPartOfTheASCIITable
    {
        static void Main(string[] args)
        {
            int firstIndex = int.Parse(Console.ReadLine());
            int lastIndex = int.Parse(Console.ReadLine());

            for (char i = (char)firstIndex; i <= (char)lastIndex; i++)
            {
                if (i == (char)lastIndex)
                {
                    Console.Write(i);
                }
                else
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
