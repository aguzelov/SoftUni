using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RoliTheCoder
{
    class RoliTheCoder
    {
        private static Dictionary<int, Event> events = new Dictionary<int, Event> { };

        private static bool ValidateEvent(string eventInfo)
        {
            Regex regex = new Regex(@"\d+\s#\w+(\s@{1}\w+)*");
            Match match = regex.Match(eventInfo);

            if (match.Success)
            {
                return true;
            }

            return false;
        }

        private static void PrintEvents()
        {
            foreach (var e in events.OrderByDescending(x => x.Value.Participants.Count).ThenBy(x => x.Value.EventName))
            {
                e.Value.PrintEvent();
            }
        }

        private static void AddEvent(int id, string name, string[] participants)
        {
            if (events.ContainsKey(id))
            {
                if (events[id].EventName != name)
                {
                    return;
                }
                else
                {
                    events[id].AddParticipants(participants);
                }
            }
            else
            {
                events.Add(id, new Event(id, name, participants));
            }
        }

        private static void ExtractInfoFromInput(string input)
        {
            string[] eventInfo = input.Split(new char[] { ' ', }, StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToArray();

            int id = int.Parse(eventInfo[0]);

            string eventName = eventInfo[1];
            eventName = eventName.Remove(0, 1);

            string[] paricipants = eventInfo.Skip(2).Take(eventInfo.Length - 2).ToArray();

            AddEvent(id, eventName, paricipants);
        }

        private static bool TakeEvent()
        {
            string input = Console.ReadLine();

            if (input == "Time for Code")
            {
                PrintEvents();
                return false;
            }

            if (!ValidateEvent(input))
            {
                return true;
            }

            ExtractInfoFromInput(input);

            return true;
        }

        static void Main(string[] args)
        {
            while (TakeEvent())
            {
            }
        }
    }

    class Event
    {
        private int id;
        private string eventName;
        private List<string> participants = new List<string>();

        public Event(int id, string name, string[] participant)
        {
            this.id = id;
            this.eventName = name;
            this.participants.AddRange(participant.Distinct());
        }

        public int Id { get => id; set => id = value; }
        public string EventName { get => eventName; set => eventName = value; }
        public List<string> Participants { get => participants; set => participants = value; }

        public void AddParticipants(string[] participant)
        {
            foreach (string name in participant.Distinct())
            {
                if (!participants.Contains(name))
                {
                    participants.Add(name);
                }
            }
        }

        public void PrintEvent()
        {
            Console.WriteLine($"{eventName} - {participants.Count}");
            foreach (string name in participants.OrderBy(x => x).Distinct())
            {
                Console.WriteLine($"{name}");
            }
        }
    }
}