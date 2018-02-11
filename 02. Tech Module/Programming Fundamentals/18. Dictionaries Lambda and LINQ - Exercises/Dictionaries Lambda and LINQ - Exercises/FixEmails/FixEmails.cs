using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixEmails
{
    class FixEmails
    {
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
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }

        static void TakeInput(out string name, out string email)
        {
            name = Console.ReadLine();
            email = "";
            if (name == "stop")
            {
                PrintEmails();
                return;
            }
            email = Console.ReadLine();
        }

        static void Main(string[] args)
        {
            TakeInput(out string name, out string email);
            while (name != "stop")
            {
                AddEmail(name, email);
                TakeInput(out name, out email);
            }
        }
    }
}
