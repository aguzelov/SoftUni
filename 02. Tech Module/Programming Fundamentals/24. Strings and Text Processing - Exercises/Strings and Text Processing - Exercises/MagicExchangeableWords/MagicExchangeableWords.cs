using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicExchangeableWords
{
    class MagicExchangeableWords
    {
        static Dictionary<char, char> exchangeableChars = new Dictionary<char, char> { };


        static void TakeStringArray(out string[] array)
        {
            array = Console.ReadLine()
                           .Split(' ')
                           .Select(p => p.Trim())
                           .ToArray();
        }

        static void Main(string[] args)
        {
            TakeStringArray(out string[] input);

            string firstString = input[0];
            int firstStringLength = firstString.Length;

            string secondString = input[1];
            int secondStringLength = secondString.Length;

            int minStringLength = Math.Min(firstStringLength, secondStringLength);

            for (int i = 0; i < minStringLength; i++)
            {
                if (!exchangeableChars.ContainsKey(firstString[i]))
                {
                    if (!exchangeableChars.ContainsValue(secondString[i]))
                    {
                        exchangeableChars.Add(firstString[i], secondString[i]);

                    }
                    else
                    {
                        Console.WriteLine("false");
                        return;
                    }
                }
                else if (exchangeableChars[firstString[i]] != secondString[i])
                {
                    Console.WriteLine("false");
                    return;
                }
            }

            string stringWithLargeLength = firstStringLength >= secondStringLength ? firstString : secondString;

            foreach (char c in stringWithLargeLength)
            {
                if (!exchangeableChars.ContainsKey(c) &&
                        !exchangeableChars.ContainsValue(c))
                {
                    Console.WriteLine("false");
                    return;
                }
            }
            Console.WriteLine("true");
        }
    }
}
