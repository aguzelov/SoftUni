using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regexmon
{
    class Regexmon
    {

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Didimon didimon = new Didimon();
            Bojomon bojomon = new Bojomon();

            while (input.Length > 0)
            {
                didimon.Add(ref input);
                bojomon.Add(ref input);
            }

        }
    }

    class Didimon
    {
        private readonly string pattern = @"(^|(?<=[\w-]))([^a-zA-Z-]+)($|(?=[\w-]))";

        public void Add(ref string input)
        {
            MatchCollection matches = Regex.Matches(input, pattern);
            if (matches.Count != 0)
            {
                string text = matches[0].Value;
                int index = input.IndexOf(text);
                input = input.Remove(0, index + text.Length);
                Console.WriteLine(text);
            }
            else
            {
                input = input.Remove(0, input.Length);
            }
        }
    }

    class Bojomon
    {
        private readonly string pattern = @"([a-zA-Z]+)-([a-zA-Z]+)";

        public void Add(ref string input)
        {
            MatchCollection matches = Regex.Matches(input, pattern);
            if (matches.Count != 0)
            {
                string text = matches[0].Value;
                int index = input.IndexOf(text);
                input = input.Remove(0, index + text.Length);
                Console.WriteLine(text);
            }
            else
            {
                input = input.Remove(0, input.Length);
            }
        }
    }
}
