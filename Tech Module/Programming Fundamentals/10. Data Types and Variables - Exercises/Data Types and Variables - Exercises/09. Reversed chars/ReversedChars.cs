using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Reversed_chars
{
    class ReversedChars
    {
        static void Main(string[] args)
        {
            char[] charArr = new char[3];
            for(int i = 0; i< charArr.Length; i++)
            {
                charArr[i] = char.Parse(Console.ReadLine());
            }
            Array.Reverse(charArr);
            foreach(char letter in charArr)
            {
                Console.Write(letter);
            }
        }
    }
}
