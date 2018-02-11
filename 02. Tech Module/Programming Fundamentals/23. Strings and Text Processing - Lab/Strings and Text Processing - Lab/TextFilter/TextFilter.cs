using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFilter
{
    class TextFilter
    {
        static void Main(string[] args)
        {
            List<string> banList = Console.ReadLine()
                                          .Split(new char[] { ',' })
                                          .Select(p => p.Trim())
                                          .Where(p => !string.IsNullOrWhiteSpace(p))
                                          .ToList();

            string text = Console.ReadLine();

            foreach (string banWord in banList)
            {
                text = text.Replace(banWord, new string('*', banWord.Length));
            }
            Console.WriteLine(text);
        }
    }
}
