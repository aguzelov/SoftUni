using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HornetComm
{
    class HornetComm
    {
        private static List<Comm> communication = new List<Comm>();

        private static void Print()
        {
            Console.WriteLine("Broadcasts:");
            var broadcasts = communication.Where(x => x.Type == "Broadcasts:").ToList();
            if(broadcasts.Count != 0)
            {
                broadcasts.ForEach(x => x.Print());
            }
            else
            {
                Console.WriteLine("None");
            }
            
            Console.WriteLine("Messages:");
            var messages = communication.Where(x => x.Type == "Messages:").ToList();
            if (messages.Count != 0)
            {
                messages.ForEach(x => x.Print());
            }
            else
            {
                Console.WriteLine("None");
            }
        }

        private static bool TakeLine()
        {
            string input = Console.ReadLine();
            if (input == "Hornet is Green")
            {
                Print();
                return false;
            }

            string messagePattern = @"^(?<first>\d+)\s<->\s(?<second>[0-9a-zA-Z]+)$";
            string broadcastPattern = @"^(?<first>\D+)\s<->\s(?<second>[A-Za-z0-9]+)$";


            if (Regex.Match(input, messagePattern).Success)
            {
                Match messageMatch = Regex.Match(input, messagePattern);
                string firstQuery = messageMatch.Groups["first"].Value;
                string secondQuery = messageMatch.Groups["second"].Value;
                communication.Add(new Message(firstQuery, secondQuery));
            }
            else if (Regex.Match(input, broadcastPattern).Success)
            {
                Match broadcastMatch = Regex.Match(input, broadcastPattern);
                string firstQuery = broadcastMatch.Groups["first"].Value;
                string secondQuery = broadcastMatch.Groups["second"].Value;
                communication.Add(new Broadcast(firstQuery, secondQuery));
            }

            return true;
        }

        static void Main(string[] args)
        {
            while (TakeLine()) { }

        }
    }

    class Comm
    {
        protected string firstQuery;
        protected string secondQuery;
        private readonly string type;

        public Comm(string first, string second, string type)
        {
            this.type = type;
            this.firstQuery = first;
            this.secondQuery = second;
        }

        public string Type => type;

        public virtual void Print()
        {
            Console.WriteLine($"{firstQuery} -> {secondQuery}");
        }
    }

    class Message: Comm
    {
        private string recipientCode;
        private string message;
        
        public Message(string first, string second) : base(first,second, "Messages:")
        {
            ReverseCode();
            this.message = second;
        }
        

        private void ReverseCode()
        {
            char[] array = this.firstQuery.ToCharArray();
            Array.Reverse(array);
            
            this.recipientCode = new string(array);
        }

        public override void Print()
        {
            Console.WriteLine($"{recipientCode} -> {message}");
        }
    }

    class Broadcast : Comm
    {
        private string frequency;
        private string message;

        public Broadcast(string first, string second) : base(first, second, "Broadcasts:")
        {
            Еxchanges();
            this.message = first;
        }

        private void Еxchanges()
        {
            foreach(char letter in this.secondQuery)
            {
                if (char.IsLetter(letter))
                {
                    if (char.IsLower(letter))
                    {
                        this.frequency += char.ToUpper(letter);
                    }
                    else 
                    {
                        this.frequency += char.ToLower(letter);
                    }
                }
                else
                {
                    this.frequency += letter;
                }
            }
        }


        public override void Print()
        {
            Console.WriteLine($"{frequency} -> {message}");
        }
    }
}
