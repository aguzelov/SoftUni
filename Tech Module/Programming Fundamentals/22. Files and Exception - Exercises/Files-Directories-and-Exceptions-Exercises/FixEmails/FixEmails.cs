using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FixEmails
{
    class FixEmails
    {
        private static readonly string inputFileName = "input.txt";

        private static readonly string outputFileName = "output.txt";
        
        static Dictionary<string, string> emails = new Dictionary<string, string> { };

        static void AddEmail(string name, string email)
        {
            if (ValidateEmai(email))
            {
                if (emails.ContainsKey(name))
                {
                    emails[name] = email;
                }
                else
                {
                    emails.Add(name, email);
                }
            }
        }

        static bool ValidateEmai(string email)
        {
            string domainEnd = email.Substring(email.Length - 2);
            if (string.Equals(domainEnd, "us", StringComparison.OrdinalIgnoreCase)
                || string.Equals(domainEnd, "uk", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            return true;
        }

        static void PrintEmails()
        {
            foreach (KeyValuePair<string, string> pair in emails)
            {
                WriteToFile($"{pair.Key} -> {pair.Value}");
            }
            WriteToFile(String.Empty);
        }

        static void TakeInput(out string[] lines)
        {
            lines = File.ReadAllLines(inputFileName);
        }

        static void WriteToFile(string text)
        {
            using (StreamWriter writer = new StreamWriter(outputFileName, true))
            {
                writer.WriteLine(text);
            }
        }

        static void CleanOutputFile()
        {
            using (StreamWriter writer = new StreamWriter(outputFileName, false))
            {
                writer.Write(String.Empty);
            }
        }

        static void Main(string[] args)
        {
            TakeInput(out string[] lines);

            int nameIndex = 0;
            int emailIndex = 1;

            while (lines[nameIndex] != "stop")
            {
                AddEmail(lines[nameIndex], lines[emailIndex]);
                nameIndex += 2;
                emailIndex += 2;
            }

            CleanOutputFile();

            PrintEmails();
        }
    }
}
