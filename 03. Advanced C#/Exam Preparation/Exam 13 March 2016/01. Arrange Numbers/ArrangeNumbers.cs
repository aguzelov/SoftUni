using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ArrangeNumbers
{

    public static void Main()
    {
        List<int> originalNumbers = Console.ReadLine()
            .Split(new[] { ',',' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        Func<int, string> name = GetName;

        Console.WriteLine(string.Join(", ", originalNumbers.OrderBy(name).ThenBy(p => name(p).Length)));
    }

    public static string GetName(int number)
    {
        StringBuilder sb = new StringBuilder();

        string stringNumber = number.ToString();

        foreach (var num in stringNumber)
        {
            int n = int.Parse(num.ToString());

            Names name = (Names)n;
            sb.Append(name.ToString());
        }

        return sb.ToString();
    }
}

public enum Names
{
    one = 1,
    two = 2,
    three = 3,
    four = 4,
    five = 5,
    six =6,
    seven = 7,
    eight = 8,
    nine = 9,
    zero = 0
}