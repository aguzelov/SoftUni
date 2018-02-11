using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortWordsSorted
{
    class ShortWordsSorted
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                                    .Split(new char[] { '.', ',', ':', ';', '(', ')', '[', ']', '\"', '\'', '\\', '/', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Where(p => p.Length < 5)
                                    .Select(p => p.ToLower())
                                    .ToList();

            var orderedList = words.Distinct().OrderBy(x => x);
            Console.WriteLine(string.Join(", ", orderedList));
        }
    }
}
