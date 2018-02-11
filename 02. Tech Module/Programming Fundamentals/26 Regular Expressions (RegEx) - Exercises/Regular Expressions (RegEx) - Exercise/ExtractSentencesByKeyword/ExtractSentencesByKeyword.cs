using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtractSentencesByKeyword
{
    class ExtractSentencesByKeyword
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            string text = Console.ReadLine();

            string[] textArray = Regex.Split(text, @"[.!?]").Select(p => p.Trim()).ToArray();

            string pattern = $"(^|(?<=\\s)|([.!?]))(.*?\\s?{word}\\s.+?)($|([.?!]))";

            foreach (string line in textArray)
            {
                if (Regex.IsMatch(line, pattern))
                {
                    Console.WriteLine(line);
                }
            }

        }
    }
}
