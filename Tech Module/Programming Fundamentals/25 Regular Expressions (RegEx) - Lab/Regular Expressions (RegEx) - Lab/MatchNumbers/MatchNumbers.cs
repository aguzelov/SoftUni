using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchNumbers
{
    class MatchNumbers
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            var numbers = matches.Cast<Match>().Select(a => a.Value.Trim()).ToArray();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
