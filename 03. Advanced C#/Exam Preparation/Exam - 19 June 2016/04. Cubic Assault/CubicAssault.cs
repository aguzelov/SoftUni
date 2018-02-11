using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text.RegularExpressions;

public class CubicAssault
{
    private static Dictionary<string, Dictionary<string, long>> regions = new Dictionary<string, Dictionary<string, long>>();

    public static void Main()
    {
        while (TakeInput(out string region, out string legion, out long amount))
        {
            if (!regions.ContainsKey(region))
            {
                regions.Add(region, new Dictionary<string, long>()
                {
                    {"Green", 0L },
                    {"Red", 0L },
                    {"Black", 0L }
                });
            }

            regions[region][legion] += amount;

            SetRegions(region);
        }

        Print();
    }

    private static void Print()
    {
        regions = regions.OrderByDescending(r => r.Value["Black"]).ThenBy(r => r.Key.Length).ThenBy(r => r.Key).ToDictionary(x => x.Key, v => v.Value);

        foreach (var region in regions)
        {
            Console.WriteLine(region.Key);
            foreach (var legion in region.Value.OrderByDescending(v => v.Value).ThenBy(n => n.Key))
            {
                Console.WriteLine($"-> {legion.Key} : {legion.Value}");
            }
        }
    }

    private static void SetRegions(string region)
    {
        if (regions[region]["Green"] >= 1000000)
        {
            long greenAmount = regions[region]["Green"];
            long toMove = greenAmount / 1000000;
            regions[region]["Green"] = greenAmount % 1000000;
            regions[region]["Red"] += toMove;
        }

        if (regions[region]["Red"] >= 1000000)
        {
            long redAmount = regions[region]["Red"];
            long toMove = redAmount / 1000000;
            regions[region]["Red"] = redAmount % 1000000;
            regions[region]["Black"] += toMove;
        }
    }

    private static bool TakeInput(out string region, out string legion, out long amount)
    {
        region = String.Empty;
        legion = String.Empty;
        amount = 0;

        string input = Console.ReadLine();
        if (input == "Count em all") return false;

        string[] inputArray = input
            .Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        region = inputArray[0];
        legion = inputArray[1];
        amount = long.Parse(inputArray[2]);

        return true;
    }
}