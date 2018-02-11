using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookUpgrade
{
    class PhonebookUpgrade
    {
        static List<string> contacts = new List<string>();

        static Dictionary<string, string> phonebook = new Dictionary<string, string> { };

        static void AddToPhonebook(string name, string number)
        {
            if (phonebook.ContainsKey(name))
            {
                phonebook[name] = number;
            }
            else
            {
                phonebook.Add(name, number);
                contacts.Add(name);
            }
        }

        static void SearchInPhonebook(string name)
        {
            if (phonebook.ContainsKey(name))
            {
                Console.WriteLine($"{name} -> {phonebook[name]}");
            }
            else
            {
                Console.WriteLine($"Contact {name} does not exist.");
            }
        }

        static void ListAll()
        {
            contacts = contacts.OrderBy(x => x).ToList();
            PrintNames();
        }

        static void PrintNames()
        {
            foreach (string contact in contacts)
            {
                Console.WriteLine($"{contact} -> {phonebook[contact]}");
            }
        }

        static void Main(string[] args)
        {
            string command = "";

            while (command != "END")
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();

                command = input[0];

                if (command == "A")
                {
                    string name = input[1];
                    string number = input[2];
                    AddToPhonebook(name, number);
                }
                else if (command == "S")
                {
                    string name = input[1];
                    SearchInPhonebook(name);
                }
                else if (command == "ListAll")
                {
                    ListAll();
                }
            }
        }
    }
}
