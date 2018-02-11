using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.IndexOfLetters
{
    class IndexOfLetters
    {
        static char[] GenerateArrayOfLetters()
        {
            List<char> letters = new List<char>();

            for(char i = 'a'; i <= 'z'; i++)
            {
                letters.Add(i);
            }

            return letters.ToArray();
        }

        static void Main(string[] args)
        {
           char[] letters = GenerateArrayOfLetters();

            char[] inputWord = Console.ReadLine().ToCharArray();

            for(int i = 0; i < inputWord.Length; i++)
            {
                Console.WriteLine("{0} -> {1}",inputWord[i],Array.IndexOf(letters, inputWord[i]));
            }

        }
    }
}
