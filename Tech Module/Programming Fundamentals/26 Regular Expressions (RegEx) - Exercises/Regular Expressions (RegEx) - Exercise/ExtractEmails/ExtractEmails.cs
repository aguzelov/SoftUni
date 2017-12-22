using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtractEmails
{
    class ExtractEmails
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(^|(?<=\s))([a-zA-Z0-9]+[-_\.]?[a-zA-Z0-9]+)\@([a-zA-Z]+[-_\.]?[a-zA-Z0-9]+(\.[a-zA-Z]+)+)";

            foreach (Match m in Regex.Matches(input, pattern))
            {
                Console.WriteLine(m.Groups[0].Value);
            }
        }
    }
}
