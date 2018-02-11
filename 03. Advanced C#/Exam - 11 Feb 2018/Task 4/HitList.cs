using System;
using System.Collections.Generic;
using System.Linq;

public class HitList
{
    private static readonly Dictionary<string, Dictionary<string, string>> people =
        new Dictionary<string, Dictionary<string, string>>();

    public static void Main()
    {
        var infoIndex = int.Parse(Console.ReadLine());

        var input = string.Empty;
        while ((input = Console.ReadLine()) != "end transmissions")
        {
            var nameAndPairs = input.Split(new[] {'='}, StringSplitOptions.RemoveEmptyEntries);

            var name = nameAndPairs[0];
            var pairs = nameAndPairs[1].Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);

            if (!people.ContainsKey(name)) people.Add(name, new Dictionary<string, string>());

            foreach (var pair in pairs)
            {
                var currenPair = pair.Split(new[] {':'}, StringSplitOptions.RemoveEmptyEntries);
                var key = currenPair[0];
                var value = currenPair[1];

                if (!people[name].ContainsKey(key)) people[name].Add(key, value);

                people[name][key] = value;
            }
        }

        var nameToKill = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)[1];

        Console.WriteLine($"Info on {nameToKill}:");
        var currentInfoIndex = 0;
        foreach (var info in people[nameToKill].OrderBy(k => k.Key))
        {
            currentInfoIndex += info.Key.Length;
            currentInfoIndex += info.Value.Length;
            Console.WriteLine($"---{info.Key}: {info.Value}");
        }

        Console.WriteLine($"Info index: {currentInfoIndex}");
        if (currentInfoIndex >= infoIndex)
            Console.WriteLine("Proceed");
        else
            Console.WriteLine($"Need {infoIndex - currentInfoIndex} more info.");
    }
}