using System;
using System.Linq;

public class CustomComparator
{
    public static void Main()
    {
        var array = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        var evenNumbers = array.FindAll(x => x % 2 == 0);
        evenNumbers.Sort();
        var oddNumbers = array.FindAll(x => x % 2 != 0);
        oddNumbers.Sort();

        Console.WriteLine(string.Join(" ", evenNumbers.Concat(oddNumbers)));
    }
    
}
