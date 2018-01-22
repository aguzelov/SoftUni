using System;
using System.Collections.Generic;
using System.Linq;

class BasicQueueOperations
{
    static void Main()
    {
        int[] input = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        int n = input[0];
        int s = input[1];
        int x = input[2];

        int[] inputSequence = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        Queue<int> queue = new Queue<int>();

        for (int i = 0; i < n; i++)
        {
            queue.Enqueue(inputSequence[i]);
        }

        for (int i = 0; i < s; i++)
        {
            queue.Dequeue();
        }

        int minElement = queue.Count == 0 ? 0 : queue.Min();

        Console.WriteLine(queue.Contains(x) ? "true" : minElement.ToString());
    }
}
