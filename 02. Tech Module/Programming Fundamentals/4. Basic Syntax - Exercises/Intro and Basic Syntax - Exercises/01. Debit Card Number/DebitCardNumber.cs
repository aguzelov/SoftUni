using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Debit_Card_Number
{
    class DebitCardNumber
    {
        static string debitCardNumber = "";
        static void appendNumber(string number)
        {
            debitCardNumber += number;
        }
        static void printNumber()
        {
            Console.WriteLine(debitCardNumber);
        }
        static void Main(string[] args)
        {
            for(int i = 0; i < 4; i++)
            {
                appendNumber(String.Format("{0:0000}", int.Parse(Console.ReadLine())));
                if(i < 3)
                {
                    appendNumber(" ");
                }
            }
            printNumber();
        }
    }
}
