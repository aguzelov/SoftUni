using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReplaceATag
{
    class ReplaceATag
    {
        private static string pattern = @"<a.*?href.*?=(.*)>(.*?)<\/a>";
        private static string replacement = @"[URL href=$1]$2[/URL]";


        private static bool TakeInput()
        {
            string input = Console.ReadLine();

            if (input == "end")
            {
                return false;
            }

            string replaced = Regex.Replace(input, pattern, replacement);

            Console.WriteLine(replaced);

            return true;
        }

        static void Main(string[] args)
        {
            while (TakeInput()) { }
        }
    }
}
