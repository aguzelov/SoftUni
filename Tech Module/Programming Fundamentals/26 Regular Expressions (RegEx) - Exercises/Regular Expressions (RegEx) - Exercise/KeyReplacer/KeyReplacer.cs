using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KeyReplacer
{
    class KeyReplacer
    {
        static void Main(string[] args)
        {
            string keyString = Console.ReadLine();

            string pattern = @"(?<start>^\w+)([\|<\\]).+([\|<\\])(?<end>\w+$)";

            string start = "";
            string end = "";

            Regex regex = new Regex(pattern);
            Match match = regex.Match(keyString);

            if (match.Success)
            {
                start = match.Groups["start"].Value;
                end = match.Groups["end"].Value;
            }


            string text = Console.ReadLine();

            pattern = @"(" + start + ")(?<text>.*?)(" + end + ")";

            regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            string result = "";
            foreach (Match m in matches)
            {
                result += m.Groups["text"].Value;
            }

            if (result.Length > 0)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Empty result");
            }
        }
    }
}
