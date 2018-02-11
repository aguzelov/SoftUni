using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RoliTheCoder
{
    class RoliTheCoder
    {
        private static Dictionary<string, Event> events = new Dictionary<string, Event>();

        private static void AddEvent(string id, string eventName, List<string> participants)
        {
            if (events.ContainsKey(id))
            {

                if (events[id].Name == eventName)
                {
                    events[id].AddParticipants(participants);
                }
            }
            else
            {
                events.Add(id, new Event(id, eventName, participants));
            }
        }

        private static void GetIdAndEvent(string input, out string id, out string eventName)
        {
            id = null;
            eventName = null;

            string pattern = @"(^)(?<id>\d+)(\s+\#)(?<event>.+?)($|(?=\s))";

            Match match = Regex.Match(input, pattern);
            if (match.Success)
            {
                id = match.Groups["id"].Value;
                eventName = match.Groups["event"].Value;
            }
        }

        private static void GetParticipants(string input, out List<string> participants)
        {
            participants = new List<string>();

            string pattern = @"(?<=\@)(?<participant>.+?)($|(?=\s))";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                participants.Add(match.Value);
            }
        }

        private static void Print()
        {


            foreach (var e in events.OrderByDescending(x => x.Value.Paritcipants.Count).ThenBy(x => x.Value.Name))
            {
                e.Value.Print();
            }
        }

        private static bool TakeEvent()
        {
            string input = Console.ReadLine();
            if (input == "Time for Code")
            {
                Print();
                return false;
            }

            GetIdAndEvent(input, out string id, out string eventName);
            if (id == null || eventName == null)
            {
                return true;
            }
            GetParticipants(input, out List<string> participants);

            AddEvent(id, eventName, participants);

            return true;
        }

        static void Main(string[] args)
        {
            while (TakeEvent()) { }
        }
    }

    class Event
    {
        private string id;
        private string name;
        private List<string> paritcipants = new List<string>();

        public Event(string id, string name, List<string> list)
        {
            this.id = id;
            this.name = name;
            this.paritcipants.AddRange(list);
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public List<string> Paritcipants { get => paritcipants; set => paritcipants = value; }

        public void AddParticipants(List<string> list)
        {
            foreach (string name in list)
            {
                if (!paritcipants.Contains(name))
                {
                    this.paritcipants.Add(name);
                }
            }
        }

        public void Print()
        {
            this.paritcipants = paritcipants.Distinct().ToList();
            Console.WriteLine($"{this.name} - {this.paritcipants.Count}");

            foreach (string p in paritcipants.OrderBy(x => x))
            {
                Console.WriteLine($"@{p}");
            }
        }
    }
}
