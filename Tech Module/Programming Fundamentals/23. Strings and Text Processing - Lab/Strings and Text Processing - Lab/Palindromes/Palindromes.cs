using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes
{
    class Palindromes
    {
        static bool IsPalindrom(string word)
        {
            string firstPart = word.Substring(0, word.Length / 2);

            char[] arr = word.ToCharArray();
            Array.Reverse(arr);
            string reversedArr = new string(arr);

            string secondPart = reversedArr.Substring(0, reversedArr.Length / 2);
            return firstPart.Equals(secondPart);
        }

        static void Main(string[] args)
        {
            List<string> text = Console.ReadLine()
                                        .Split(new char[] { ' ', ',', '.', '!', '?', ':', ';' })
                                        .Where(p => !string.IsNullOrWhiteSpace(p))
                                        .Select(p => p.Trim())
                                        .ToList();

            List<string> resultList = new List<string>();

            foreach(string word in text)
            {
                if (IsPalindrom(word))
                {
                    resultList.Add(word);
                }
            }

            Console.WriteLine(string.Join(", ", resultList.OrderBy(x=> x).Distinct().ToList()));
        }
    }
}
