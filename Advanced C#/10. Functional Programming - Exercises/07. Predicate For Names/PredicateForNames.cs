using System;
using System.Collections.Generic;
using System.Linq;

public class PredicateForNames
{
    public static void Main()
    {
        int length = int.Parse(Console.ReadLine());

        List<string> names = Console.ReadLine().Split(' ').ToList();

        names = names.FindAll(n => n.Length <= length);

        Console.WriteLine(string.Join(Environment.NewLine, names));
    }
}
