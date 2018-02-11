using System;
using System.Collections.Generic;
using System.Linq;

public class TriFunction
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<string> names = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        Func<string, int, bool> myFunc = IsEqualOrLarger;
        string name = First(names, n, myFunc);
        Console.WriteLine(name);
    }

    private static string First(List<string> names, int n, Func<string, int, bool> myFunc)
    {
        string firstMatching = "";

        foreach (var name in names)
        {
            if (myFunc(name, n))
            {
                firstMatching = name;
                break;
            }
        }
        return firstMatching;
    }

    private static bool IsEqualOrLarger(string name, int n)
    {
        int sum = 0;
        foreach (var c in name)
        {
            sum += (int)c;
        }

        return sum >= n;
    }
}
