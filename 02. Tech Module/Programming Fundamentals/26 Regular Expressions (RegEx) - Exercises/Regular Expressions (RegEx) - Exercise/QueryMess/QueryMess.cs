using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QueryMess
{
    class QueryMess
    {
        private static Dictionary<string, List<string>> pairs = new Dictionary<string, List<string>>();

        private static void PrintResult()
        {
            foreach (var pair in pairs)
            {
                Console.Write(pair.Key + "=");
                Console.Write("[" + string.Join(", ", pair.Value) + "]");

            }
            Console.WriteLine();
        }

        private static void AddToPairs(string field, string key)
        {
            field = Regex.Replace(field, @"(\+)|(%20)", " ");
            field = field.Trim();
            field = Regex.Replace(field, @"(\s+)", " ");

            key = Regex.Replace(key, @"(\+)|(%20)", " ");
            key = key.Trim();
            key = Regex.Replace(key, @"(\s+)", " ");

            if (pairs.ContainsKey(field))
            {
                pairs[field].Add(key);
            }
            else
            {
                pairs.Add(field, new List<string> { key });
            }
        }

        private static bool TakeInput()
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                return false;
            }

            string[] splitedInput = Regex.Split(input, @"\?").ToArray();

            string pattern = @"(^|(?<=&))(?<field>.+?)=(?<key>.*?)($|(?=&))";

            Regex regex = new Regex(pattern);


            foreach (string line in splitedInput)
            {
                MatchCollection matches = regex.Matches(line);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        //Console.WriteLine("field: " + match.Groups["field"].Value + "     key: " + match.Groups["key"].Value);
                        AddToPairs(match.Groups["field"].Value, match.Groups["key"].Value);
                    }
                }
            }

            PrintResult();
            pairs.Clear();

            return true;
        }

        static void Main(string[] args)
        {
            while (TakeInput())
            {

            }
        }
    }
}
