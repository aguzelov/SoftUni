using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UseYourChainsBuddy
{
    class UseYourChainsBuddy
    {
        private static string decryptedMessage = "";

        private static void Decrypt(string text)
        {
            string newText = "";
            foreach (char c in text)
            {
                if (c >= 'a' && c <= 'm')
                {
                    newText += (char)(c + 13);
                }
                else if (c >= 'n' && c <= 'z')
                {
                    newText += (char)(c - 13);
                }
                else
                {
                    newText += c;
                }
            }
            newText = Regex.Replace(newText, @"(\s+)", " ");
            decryptedMessage += newText;
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(?<=<p>).*?(?=</p>)";
            string[] extractedText = Regex.Matches(input, pattern)
                                           .Cast<Match>()
                                           .Select(a => a.Value)
                                           .ToArray();

            for (int i = 0; i < extractedText.Length; i++)
            {
                Decrypt(Regex.Replace(extractedText[i], @"[^a-z0-9]+", " "));
            }

            if (decryptedMessage.Length > 0)
            {
                Console.WriteLine(decryptedMessage);
            }
        }
    }
}
