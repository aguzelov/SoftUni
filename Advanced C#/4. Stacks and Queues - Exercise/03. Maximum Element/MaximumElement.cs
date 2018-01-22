using System;
using System.Collections.Generic;
using System.Linq;

class MaximumElement
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Stack<int> stack = new Stack<int>();
        int maxElement = 0;

        for (int i = 0; i < n; i++)
        {
            int[] input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            switch (input[0])
            {
                case 1:
                    stack.Push(input[1]);
                    if(maxElement < input[1])
                    {
                        maxElement = input[1];
                    }
                    break;
                case 2:
                    int element = stack.Pop();

                    if(element == maxElement && stack.Count > 0)
                    {
                        maxElement = stack.Max();
                    }
                    else if(element == maxElement && stack.Count == 0)
                    {
                        maxElement = 0;
                    }
                    break;
                case 3:
                    Console.WriteLine(maxElement);
                    break;
            }
        }
    }
}
