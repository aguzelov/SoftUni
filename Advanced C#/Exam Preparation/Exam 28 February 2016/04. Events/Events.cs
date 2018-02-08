using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Schema;

public class Events
{
    private static Dictionary<string, Dictionary<string, List<string>>> locations = new Dictionary<string, Dictionary<string, List<string>>>();

    public static void Main()
    {
        string pattern =
            @"^(?:#)(?<name>[a-zA-Z]+?)(?::)\s*(?:@)(?<location>[a-zA-Z]+?)\s*(?<hour>(([0-9])|([0-1][0-9])|([2][0-3])+?):(([0-9])|([0-5][0-9])))$";

        int eventCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < eventCount; i++)
        {
            string input = Console.ReadLine();

            Match match = Regex.Match(input, pattern);
            if (!match.Success) continue;

            string person = match.Groups["name"].Value;
            string location = match.Groups["location"].Value;
            string hour = match.Groups["hour"].Value;

            Add(person, location, hour);
        }

        Print();
    }

    private static void Print()
    {
        string[] searchedLocation = Console.ReadLine()
            .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var location in locations.Where(k => searchedLocation.Contains(k.Key)).OrderBy(k => k.Key).ToDictionary(k => k.Key, v => v.Value))
        {
            Console.WriteLine($"{location.Key}:");
            int counter = 1;
            foreach (var nameAndTimes in location.Value.OrderBy(k => k.Key))
            {
                Console.WriteLine($"{counter++}. {nameAndTimes.Key} -> {string.Join(", ", nameAndTimes.Value.OrderBy(x => x))}");
            }
        }
    }

    private static void Add(string person, string location, string hour)
    {
        if (!locations.ContainsKey(location))
        {
            locations.Add(location, new Dictionary<string, List<string>>());
        }

        if (!locations[location].ContainsKey(person))
        {
            locations[location].Add(person, new List<string>());
        }

        locations[location][person].Add(hour);
    }
}