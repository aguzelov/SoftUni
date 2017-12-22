using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Phoenix_Grid
{
    class Phoenix_Grid
    {
        static void Main(string[] args)
        {
            while (TakeLine()) { }
        }

        private static bool TakeLine()
        {
            string input = Console.ReadLine();
            if (input == "ReadMe")
            {
                return false;
            }

            string pattern = @"^([^\s_]{3}\.)+([^\s_]{3})*$";


            if (Regex.IsMatch(input, pattern) || input.Length == 3)
            {
                if (IsPalindrome(input))
                {
                    Console.WriteLine("YES");
                }
            }
            else
            {
                Console.WriteLine("NO");
            }

            return true;
        }

        private static bool IsPalindrome(string word)
        {
            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length - 1 - i])
                {
                    Console.WriteLine("NO");
                    return false;
                }
            }

            return true;
        }
    }
}
