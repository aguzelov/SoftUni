using System;
using System.Collections.Generic;
using System.Linq;

public class CollectResources
{
    private static List<Path> paths = new List<Path>();
    private static string[] resources;

    public static void Main()
    {
        resources = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        int numberOfPath = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfPath; i++)
        {
            int[] pathParam = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int start = pathParam[0];
            int step = pathParam[1];
            paths.Add(new Path(start, step));
        }

        long maxResources = int.MinValue;
        foreach (var path in paths)
        {
            long currentResources = CountResources(path);
            if (currentResources > maxResources)
            {
                maxResources = currentResources;
            }
        }

        Console.WriteLine(maxResources);
    }

    private static long CountResources(Path path)
    {
        int index = path.Start;
        int step = path.Step;

        List<string> temp = new List<string>(resources);

        long collectSum = 0;

        while (true)
        {
            if (temp[index] == "X") break;

            KeyValuePair<string, int> resource = GetInfo(temp[index]);
            if (resource.Key == "stone" ||
                resource.Key == "gold" ||
                resource.Key == "wood" ||
                resource.Key == "food")
            {
                collectSum += resource.Value;
            }

            temp[index] = "X";

            index += step;
            index = index >= temp.Count ? index % temp.Count : index;
        }

        return collectSum;
    }

    private static KeyValuePair<string, int> GetInfo(string resource)
    {
        int index = resource.IndexOf("_");

        string name = String.Empty;
        int quantity;

        if (index < 0)
        {
            name = resource;
            quantity = 1;
            return new KeyValuePair<string, int>(name, quantity);
        }

        name = resource.Substring(0, index);
        quantity = int.Parse(resource.Substring(index + 1, resource.Length - (index + 1)));
        return new KeyValuePair<string, int>(name, quantity);

    }
}

public class Path
{
    public int Start { get; set; }
    public int Step { get; set; }

    public Path(int start, int step)
    {
        Start = start;
        Step = step;
    }
}
