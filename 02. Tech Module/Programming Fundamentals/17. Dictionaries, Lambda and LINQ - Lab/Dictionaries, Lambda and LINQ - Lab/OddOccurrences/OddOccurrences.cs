using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddOccurrences
{
    class OddOccurrences
    {
        static Dictionary<string, int> occurrences = new Dictionary<string, int> { };

        static void FillOccurrences(List<string> list)
        {
            foreach (string text in list)
            {
                if (occurrences.ContainsKey(text))
                {
                    occurrences[text] += 1;
                }
                else
                {
                    occurrences.Add(text, 1);
                }
            }
        }

        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Where(p => !string.IsNullOrWhiteSpace(p))
                                        .Select(p => p.ToLower())
                                        .ToList();

            
            FillOccurrences(input);

            List<string> result = new List<string>();
            foreach (KeyValuePair<string, int> pair in occurrences)
            {
                if (pair.Value % 2 != 0)
                {
                    result.Add(pair.Key);
                }
            }
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
