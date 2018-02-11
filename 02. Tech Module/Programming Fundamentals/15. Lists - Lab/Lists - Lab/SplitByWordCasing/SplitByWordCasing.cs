using System;
using System.Collections.Generic;
using System.Linq;

namespace SplitByWordCasing
{
    class SplitByWordCasing
    {
        static bool IsAllUpper(string word)
        {
            int counte = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (Char.IsUpper(word[i]))
                {
                    counte++;
                }
            }
            if (counte < word.Length)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static bool IsAllLower(string word)
        {
            int counte = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (Char.IsLower(word[i]))
                {
                    counte++;
                }
            }
            if (counte < word.Length)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static void Main(string[] args)
        {
            ListMethods.ReceiveStringList(out List<string> list, new[] { " ", ",", ";", ":", ".", "!", "(", ")", "\"", "'", "\\", "/", "[", "]" });

            List<string> lowerCaseWords = new List<string>();
            List<string> upperCaseWords = new List<string>();
            List<string> mixCaseWords = new List<string>();

            foreach (string word in list)
            {
                bool haveUpperChar = word.ToCharArray().Any(c => char.IsUpper(c));
                if (IsAllUpper(word))
                {
                    upperCaseWords.Add(word);
                }
                else if (IsAllLower(word))
                {
                    lowerCaseWords.Add(word);
                }
                else
                {
                    mixCaseWords.Add(word);

                }
            }

            Console.WriteLine("Lower-case: " + string.Join(", ", lowerCaseWords));
            Console.WriteLine("Mixed-case: " + string.Join(", ", mixCaseWords));
            Console.WriteLine("Upper-case: " + string.Join(", ", upperCaseWords));
        }
    }
    class ListMethods
    {
        public static bool CorrectIndex<T>(List<T> list, int index)
        {
            if (index < 0 || index > list.Count - 1)
            {
                return false;
            }
            return true;
        }


        public static void ReceiveStringList(out List<string> list, string[] delimiters)
        {
            list = new List<string>();
            list = Console.ReadLine()
                .Split(delimiters, StringSplitOptions.None)
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .ToList();
        }

        public static void ReceiveIntList(out List<int> list, string[] delimiters)
        {
            list = new List<int>();
            list = Console.ReadLine()
                .Split(delimiters, StringSplitOptions.None)
                .Select(p => int.Parse(p))
                .ToList();
        }

        public static void PrintList<T>(List<T> list)
        {
            Console.WriteLine(string.Join("-", list));
        }
    }
}
