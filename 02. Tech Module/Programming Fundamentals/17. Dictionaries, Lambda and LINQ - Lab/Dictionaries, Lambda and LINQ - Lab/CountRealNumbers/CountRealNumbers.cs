using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountRealNumbers
{
    class CountRealNumbers
    {
        static Dictionary<string, int> occurrences = new Dictionary<string, int> { };

        static void Main(string[] args)
        {
            List<string> realNumber = Console.ReadLine()
                                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Where(p => !string.IsNullOrWhiteSpace(p))
                                        .ToList();

            foreach (string num in realNumber)
            {
                if (occurrences.ContainsKey(num))
                {
                    occurrences[num] += 1;
                }
                else
                {
                    occurrences.Add(num, 1);
                }
            }
            var keyList = occurrences.Keys.Select(decimal.Parse).ToList();
            keyList.Sort();

            foreach (decimal key in keyList)
            {
                Console.WriteLine($"{key} -> {occurrences[key.ToString()]}");
            }

        }
    }
}
