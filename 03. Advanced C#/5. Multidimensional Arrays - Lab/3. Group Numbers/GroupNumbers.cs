using System;
using System.Collections.Generic;
using System.Linq;

public class GroupNumbers
{
    public static void Main()
    {
        int[] input = Console.ReadLine()
            .Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Dictionary<int, List<int>> groups = new Dictionary<int, List<int>>()
        {
            {0, new List<int>() },
            {1, new List<int>() },
            {2, new List<int>() }
        };

        int remainder = 0;
        for (int i = 0; i < input.Length; i++)
        {
            remainder = Math.Abs(input[i] % 3);
            groups[remainder].Add(input[i]);
        }

        foreach (var group in groups)
        {
            Console.WriteLine(string.Join(" ", group.Value));
        }
    }
}
