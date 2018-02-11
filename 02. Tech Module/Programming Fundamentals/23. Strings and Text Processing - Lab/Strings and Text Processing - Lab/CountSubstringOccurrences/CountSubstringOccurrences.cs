using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSubstringOccurrences
{
    class CountSubstringOccurrences
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            string searchText = Console.ReadLine().ToLower();

            int count = 0, n = 0;

            while ((n = text.IndexOf(searchText, n)) != -1)
            {
                n++;
                ++count;
            }

            Console.WriteLine(count);
        }
    }
}
