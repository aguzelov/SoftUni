using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RageQuit
{
    class RageQuit
    {
        static void Main(string[] args)
        {
            string pattern = @"([^0-9]+)([0-9]+)";

            StringBuilder message = new StringBuilder();

            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                string text = match.Groups[1].Value.ToUpper();
                int count = int.Parse(match.Groups[2].Value);
                message.Append(string.Concat(Enumerable.Repeat(text.ToUpper(), count)));
            }

            Console.WriteLine($"Unique symbols used: {message.ToString().Distinct().Count()}");
            Console.WriteLine(message);
        }
    }
}
