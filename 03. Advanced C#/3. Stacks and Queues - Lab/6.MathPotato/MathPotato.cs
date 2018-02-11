using System;
using System.Collections.Generic;
using System.Linq;

class MathPotato
{
    static void Main()
    {
        string[] kidsName = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        int n = int.Parse(Console.ReadLine());

        Queue<string> kids = new Queue<string>(kidsName);

        int counter = 0;
        int cycleCounter = 1;
        while (kids.Count != 1)
        {

            string currentKid = kids.Dequeue();
            counter++;
            if (counter == n)
            {
                counter = 0;
                cycleCounter++;
                if (IsPrime(cycleCounter))
                {
                    Console.WriteLine($"Removed {currentKid}");
                }
                else
                {
                    Console.WriteLine($"Prime {currentKid}");
                    kids.Enqueue(currentKid);
                }
            }
        }

        Console.WriteLine($"Last is {kids.Peek()}");
    }

    public static bool IsPrime(int number)
    {
        if (number == 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
        {
            if (number % i == 0) return false;
        }

        return true;
    }
}
