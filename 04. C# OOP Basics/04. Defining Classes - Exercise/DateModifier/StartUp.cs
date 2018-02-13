using System;

public class StartUp
{
    static void Main(string[] args)
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();

        DateModifier dateModifier = new DateModifier();
        Console.WriteLine(dateModifier.DateDifference(firstDate, secondDate));
    }
}
