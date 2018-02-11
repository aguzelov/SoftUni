using System;
using System.Collections.Generic;

public class StackFibonacci
{
    public static void Main()
    {
        // ReSharper disable once AssignNullToNotNullAttribute
        var n = int.Parse(Console.ReadLine());

        var sequence = new Stack<long>();

        sequence.Push(1);
        sequence.Push(1);

        for (var i = 2; i < n; i++)
        {
            var second = sequence.Pop();
            var first = sequence.Pop();
            var next = first + second;

            sequence.Push(first);
            sequence.Push(second);
            sequence.Push(next);
        }
        Console.WriteLine(sequence.Peek());
    }
}
