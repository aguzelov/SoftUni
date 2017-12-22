using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelOrDigit
{
    class VowelOrDigit
    {
        public static string isVowel(string input)
        {
            
            return ("aeiouAEIOU".IndexOf(input) >= 0 ? "vowel" : "other");
        }
        public static string isDigit(string input)
        {
            return (Char.IsDigit(input[0]) ? "digit" : "other");
        }
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            Console.WriteLine(!String.IsNullOrEmpty(input) && Char.IsLetter(input[0]) ? isVowel(input) : isDigit(input));

        }

    }
}
