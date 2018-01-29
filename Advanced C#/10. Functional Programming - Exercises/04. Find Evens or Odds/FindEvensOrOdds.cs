using System;
using System.Linq;

public class FindEvensOrOdds
{
    public static void Main()
    {
        var boundDetails = Console.ReadLine()
            .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int lower = boundDetails[0];
        int upper = boundDetails[1];

        string command = Console.ReadLine();

        Predicate<int> predicate = EvenOrOdd;

        for (int i = lower; i <= upper; i++)
        {
            if (command == "even" && predicate(i))
            {
                Console.Write(i + " ");
            }
            else if (command == "odd" && !predicate(i))
            {
                Console.Write(i + " ");
            }
        }
    }

    private static bool EvenOrOdd(int number)
    {
        return number % 2 == 0;
    }
}
