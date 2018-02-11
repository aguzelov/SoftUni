using System;
using System.Collections.Generic;
using System.Linq;

public class KeyRevolver
{
    public static void Main()
    {
        var bulletPrice = int.Parse(Console.ReadLine());
        var sizeOfBarrel = int.Parse(Console.ReadLine());

        var inputBullets = Console.ReadLine()
            .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        var totalBullets = inputBullets.Count;

        inputBullets.Reverse();

        var bullets = new Queue<int>(inputBullets);

        var inputLocks = Console.ReadLine()
            .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        var locks = new Queue<int>(inputLocks);

        var value = int.Parse(Console.ReadLine());


        var barrelCounter = sizeOfBarrel;

        while (locks.Count != 0 && bullets.Count != 0)
        {
            if (barrelCounter == 0)
            {
                Console.WriteLine("Reloading!");
                barrelCounter = sizeOfBarrel;
            }

            var bullet = bullets.Dequeue();

            var lockPeek = locks.Peek();

            if (bullet > lockPeek)
            {
                Console.WriteLine("Ping!");
            }
            else
            {
                Console.WriteLine("Bang!");
                locks.Dequeue();
            }

            barrelCounter--;
        }

        if (barrelCounter == 0 && bullets.Count > 0)
        {
            Console.WriteLine("Reloading!");
            barrelCounter = sizeOfBarrel;
        }

        if (locks.Count == 0)
        {
            var bulletsCost = (totalBullets - bullets.Count) * bulletPrice;
            Console.WriteLine($"{bullets.Count} bullets left. Earned ${value - bulletsCost}");
        }
        else if (bullets.Count == 0)
        {
            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }
    }
}