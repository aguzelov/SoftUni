using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

public class Inferno
{
    public static void Main()
    {
        List<int> gems = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        Queue<KeyValuePair<string, int>> excludeCommands = new Queue<KeyValuePair<string, int>>();

        while (TakeCommand(out string[] commandParameter))
        {
            string command = commandParameter[0];
            string filterType = commandParameter[1];
            int filterParamenter = int.Parse(commandParameter[2]);

            switch (command)
            {
                case "Exclude":
                    excludeCommands.Enqueue(new KeyValuePair<string, int>(filterType, filterParamenter));
                    break;
                case "Reverse":
                    excludeCommands.Dequeue();
                    break;
            }
        }

        foreach (var currentCommand in excludeCommands.Reverse())
        {
            string filterType = currentCommand.Key;
            int filterParamenter = currentCommand.Value;

            switch (filterType)
            {
                case "Sum Left":
                    SumLeft(gems, filterParamenter);
                    break;
                case "Sum Right":
                    SumRight(gems, filterParamenter);
                    break;
                case "Sum Left Right":
                    SumLeftRight(gems, filterParamenter);
                    break;
            }
        }

        Console.WriteLine(string.Join(" ", gems));
    }

    private static void SumLeftRight(List<int> gems, int filterParamenter)
    {
        for (int i = 0; i < gems.Count; i++)
        {
            var left = (i == 0) ? 0 : gems[i - 1];
            var right = (i == gems.Count - 1) ? 0 : gems[i + 1];

            if (left + gems[i] + right == filterParamenter)
            {
                gems.RemoveAt(i);
                i--;
            }
        }
    }

    private static void SumRight(List<int> gems, int filterParamenter)
    {
        while (gems.Last() == filterParamenter && gems.Count > 0)
        {
            gems.RemoveAt(gems.Count-1);
        }

        for (int i = 0; i < gems.Count; i++)
        {
            if (gems[i] + gems[i + 1] == filterParamenter)
            {
                gems.RemoveAt(i);
                i--;
            }
        }
    }

    private static void SumLeft(List<int> gems, int filterParamenter)
    {
        while (gems.Count > 0 && gems.First() == filterParamenter)
        {
            gems.RemoveAt(0);
        }

        for (int i = gems.Count - 1; i > 0 ; i--)
        {
            if (gems[i] + gems[i-1] == filterParamenter)
            {
                gems.RemoveAt(i);
            }
        }
    }

    private static bool TakeCommand(out string[] command)
    {
        command = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (command[0] == "Forge")
        {
            return false;
        }

        return true;
    }
}
