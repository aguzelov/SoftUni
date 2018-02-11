using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchHexadecimalNumbers
{
    class MatchHexadecimalNumbers
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?:0x)?[0-9A-F]+\b";
            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);

            var numbers = regex.Matches(input).Cast<Match>()
                                             .Select(a => a.Value.Trim())
                                             .ToArray();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
