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
        private static bool ReceivingMessage()
        {
            string message = Console.ReadLine();
            if (message == "Over!")
            {
                return false;
            }

            int m = int.Parse(Console.ReadLine());

            if (!ValidateMessage(ref message, m, out int[] indexArray))
            {
                return true;
            }

            CreateVerificationCode(message, indexArray);

            return true;
        }

        private static void CreateVerificationCode(string message, int[] indexArray)
        {
            string verificationCode = "";

            foreach (int index in indexArray)
            {
                if (index >= message.Length)
                {
                    verificationCode += " ";
                }
                else
                {
                    verificationCode += message[index];
                }
            }
            Console.WriteLine($"{message} == {verificationCode}");
        }

        private static bool ValidateMessage(ref string message, int m, out int[] indexArray)
        {
            indexArray = null;

            var pattern = @"^([0-9]+)([a-zA-Z]{" + $"{m}" + @"})(" + "[^a-zA-Z]*" + ")$";
            var regex = new Regex(pattern);
            var matches = regex.Matches(message);

            if (matches.Count == 0)
            {
                return false;
            }

            message = matches[0].Value;

            string digits = Regex.Replace(message, "\\D", "");

            message = Regex.Replace(message, "[0-9\\W]", "");

            if (message.Length != m)
            {
                return false;
            }

            char[] charArray = digits.ToCharArray();

            indexArray = charArray.Select(p => int.Parse(p.ToString())).ToArray();

            return true;
        }

        static void Main(string[] args)
        {
            while (ReceivingMessage()) { }
        }
    }
}
