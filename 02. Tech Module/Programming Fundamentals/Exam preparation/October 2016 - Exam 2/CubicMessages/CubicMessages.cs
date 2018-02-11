using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CubicMessages
{
    class CubicMessages
    {
        private static string encryptedMessage;
        private static string decryptedMessage;

        private static bool ValidateIndex(int index)
        {
            if (index < 0 || index >= encryptedMessage.Length)
            {
                return false;
            }
            return true;
        }

        private static bool TakeInput()
        {
            string input = Console.ReadLine();
            if (input == "Over!")
            {
                return false;
            }
            int m = int.Parse(Console.ReadLine());

            string pattern = $"^([0-9]+)(?<line>[a-zA-Z]{{{m}}})([^a-zA-Z]*?)$";
            Match match = Regex.Match(input, pattern);
            if (match.Success)
            {
                encryptedMessage = match.Groups["line"].Value;
            }
            else
            {
                return true;
            }

            input = input.Remove(input.IndexOf(encryptedMessage), encryptedMessage.Length);

            MatchCollection matches = Regex.Matches(input, "[0-9]");

            List<int> indexes = new List<int>();

            foreach (Match number in matches)
            {
                indexes.Add(int.Parse(number.Value));
            }

            foreach (int index in indexes)
            {
                if (ValidateIndex(index))
                {
                    decryptedMessage += encryptedMessage[index];
                }
                else
                {
                    decryptedMessage += " ";
                }

            }

            Console.WriteLine($"{encryptedMessage} == {decryptedMessage}");
            encryptedMessage = "";
            decryptedMessage = "";
            return true;
        }

        static void Main(string[] args)
        {
            while (TakeInput()) { }
        }
    }
}
