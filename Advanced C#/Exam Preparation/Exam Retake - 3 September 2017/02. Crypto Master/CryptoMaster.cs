using System;
using System.Collections.Generic;
using System.Linq;

public class CryptoMaster
{
    private static List<long> _circle;

    public static void Main()
    {
        InitCircle();

        int maxSequence = 0;

        for (int index = 0; index < _circle.Count; index++)
        {
            long startNumber = _circle[index];
            int nextStep = index;

            for (int step = 1; step < _circle.Count; step++)
            {
                nextStep = (index + step) % _circle.Count;
                long currentNumber = startNumber;
                int currenSequence = 1;
                
                while (true)
                {
                    long temp = _circle[nextStep];

                    if (temp <= currentNumber )
                    {
                        break;
                    }

                    currenSequence++;

                    currentNumber = temp;
                    nextStep = (nextStep + step) % _circle.Count;
                }

                if (currenSequence > maxSequence)
                {
                    maxSequence = currenSequence;
                }
            }
        }
        Console.WriteLine(maxSequence);
    }

    private static void InitCircle()
    {
        _circle = Console.ReadLine()
            .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToList();
    }
}