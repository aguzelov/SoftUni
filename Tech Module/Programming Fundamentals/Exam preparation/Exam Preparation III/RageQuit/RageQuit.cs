using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RageQuit
{
    class RageQuit
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Message message = new Message(input);
            message.PrintInfo();
        }
    }

    class Message
    {
        private string originalMessage;
        private string rageQuitMessage;
        private HashSet<char> uniqueSymbols = new HashSet<char>();

        public Message(string message)
        {
            this.originalMessage = message;
            SetRageQuitMessage();
            SetUniqueSymbols();
        }

        private void SetUniqueSymbols()
        {
            foreach (char c in rageQuitMessage)
            {
                uniqueSymbols.Add(c);
            }
        }

        private void SetRageQuitMessage()
        {
            string patter = @".*?[0-9]+";

            List<string> parts = new List<string>();

            Regex regex = new Regex(patter);
            MatchCollection matches = regex.Matches(originalMessage);

            foreach (Match match in matches)
            {
                string subString = match.ToString();
                int number = int.Parse(Regex.Match(subString, "[0-9]+").ToString());
                subString = Regex.Replace(subString, "[0-9]", "");

                parts.Add(String.Concat(Enumerable.Repeat(subString, number)));
            }

            this.rageQuitMessage = string.Join("", parts).ToUpper();

        }

        public void PrintInfo()
        {
            Console.WriteLine("Unique symbols used: " + uniqueSymbols.Count);
            Console.WriteLine(this.rageQuitMessage);
        }

    }
}
