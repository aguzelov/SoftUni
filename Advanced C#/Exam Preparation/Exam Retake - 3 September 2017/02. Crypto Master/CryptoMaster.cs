using System;
using System.Collections.Generic;
using System.Linq;

public class CryptoMaster
{
    private static List<long> _circle;

    public static void Main()
    {
        InitCircle();

        var maxSequence = 0;

        for (var index = 0; index < _circle.Count; index++)
        {
            var startNumber = _circle[index];
            var nextStep = index;

            for (var step = 1; step < _circle.Count; step++)
            {
                nextStep = (index + step) % _circle.Count;
                var currentNumber = startNumber;
                var currenSequence = 1;

                while (true)
                {
                    var temp = _circle[nextStep];

                    if (temp <= currentNumber) break;

                    currenSequence++;

                    currentNumber = temp;
                    nextStep = (nextStep + step) % _circle.Count;
                }

                if (currenSequence > maxSequence) maxSequence = currenSequence;
            }
        }

        Console.WriteLine(maxSequence);
    }

    private static void InitCircle()
    {
        _circle = Console.ReadLine()
            .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToList();
    }
}