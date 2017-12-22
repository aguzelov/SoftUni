using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicodeCharacters
{
    class UnicodeCharacters
    {
        static string GetUnicod(char c)
        {
            return "\\u" + ((int)c).ToString("X4").ToLower();
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> unicodeSequence = new List<string>();

            foreach (char c in input)
            {
                unicodeSequence.Add(GetUnicod(c));
            }
            Console.WriteLine(string.Join("", unicodeSequence));
        }
    }
}
