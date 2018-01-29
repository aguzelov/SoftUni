using System;
using System.Linq;

public class CustomMinFunction
{
    public static void Main()
    {
        Func<int[], int> min = FindMinNumber;
        int[] arrayOfNumbers = Console.ReadLine()
            .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Console.WriteLine(min(arrayOfNumbers));
    }

    private static int FindMinNumber(int[] array)
    {
        int minNumber = int.MaxValue;
        foreach (var number in array)
        {
            if (number < minNumber)
            {
                minNumber = number;
            }
        }

        return minNumber;
    }
}
