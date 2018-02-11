using System;
using System.Collections.Generic;
using System.Linq;

class BasicStackOperations
{
    static void Main()
    {
        int[] input = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int n = input[0];
        int s = input[1];
        int x = input[2];

        int[] inputSequence = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Stack<int> stack = new Stack<int>();

        for(int i = 0; i < n; i++)
        {
            stack.Push(inputSequence[i]);
        }

        for(int i = 0; i < s; i++)
        {
            stack.Pop();
        }

        int minElement = stack.Count == 0 ? 0 : stack.Min();
        
        Console.WriteLine(stack.Contains(x) ? "true" : minElement.ToString());
    }
}
