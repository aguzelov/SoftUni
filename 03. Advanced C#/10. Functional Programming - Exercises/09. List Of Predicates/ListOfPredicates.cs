using System;
using System.Collections.Generic;
using System.Linq;

public class ListOfPredicates
{
    public static void Main()
    {
        int upperNumber = int.Parse(Console.ReadLine());

        var dividers = Console.ReadLine()
            .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        List<int> numbers = new List<int>();
        for (int i = 1; i <= upperNumber; i++)
        {
         numbers.Add(i);   
        }

        for (int i = 0; i < dividers.Count; i++)
        {
           numbers = numbers.FindAll(x => x % dividers[i] == 0).ToList();
        }
        
        Console.WriteLine(string.Join(" ", numbers));
    }
}
