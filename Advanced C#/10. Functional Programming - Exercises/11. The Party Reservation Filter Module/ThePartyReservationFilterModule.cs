using System;
using System.Collections.Generic;
using System.Linq;

public class ThePartyReservationFilterModule
{
    public static List<string> removedNames = new List<string>();

    public static void Main()
    {
        List<string> names = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        while (TakeCommand(out string[] commandParameter))
        {
            string command = commandParameter[0];
            string filterType = commandParameter[1];
            string filterParameter = commandParameter[2];

            switch (filterType)
            {
                case "Starts with":
                    ApplyFilter(names, command, n => n.StartsWith(filterParameter));
                    break;
                case "Ends with":
                    ApplyFilter(names, command, n => n.EndsWith(filterParameter));
                    break;
                case "Length":
                    int length = int.Parse(filterParameter);
                    ApplyFilter(names, command, n => n.Length == length);
                    break;
                case "Contains":
                    ApplyFilter(names, command, n => n.Contains(filterParameter));
                    break;
            }
        }

        Console.WriteLine(string.Join(" ", names));
    }

    private static void ApplyFilter(List<string> names, string command, Func<string, bool> func)
    {
        if (command == "Add filter")
        {
            for (int i = names.Count - 1; i >= 0; i--)
            {
                if (func(names[i]))
                {
                    removedNames.Add(names[i]);
                    names.RemoveAt(i);
                }
            }
        }else if (command == "Remove filter")
        {
            for (int i = 0; i < removedNames.Count; i++)
            {
                if (func(removedNames[i]))
                {
                    names.Add(removedNames[i]);
                }
            }
        }
    }

    private static bool TakeCommand(out string[] command)
    {
        command = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (command[0] == "Print")
        {
            return false;
        }

        return true;
    }
}
