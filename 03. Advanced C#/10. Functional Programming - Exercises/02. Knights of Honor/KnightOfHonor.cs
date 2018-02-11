
using System;
using System.Runtime.InteropServices;

public static class KnightOfHonor
{
    public static void Main()
    {
        Action<string> action = n => Console.WriteLine($"Sir {n}");

        foreach (var name in Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries))
        {
            action(name);
        }
    }
}
