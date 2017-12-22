using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchDates
{
    class MatchDates
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"\b(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";

            Regex regex = new Regex(pattern);

            var matches = regex.Matches(input);

            foreach (Match m in matches)
            {
                Console.WriteLine($"Day: {m.Groups["day"].Value}, " +
                                  $"Month: {m.Groups["month"].Value}, " +
                                  $"Year: {m.Groups["year"].Value}");
            }
        }
    }
}
