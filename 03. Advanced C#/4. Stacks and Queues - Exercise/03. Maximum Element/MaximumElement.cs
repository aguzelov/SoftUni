using System;
using System.Collections.Generic;
using System.Linq;

public class MaximumElement
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var stack = new Stack<int>();
        var maxElement = int.MinValue;

        for (var i = 0; i < n; i++)
        {
            var input = Console.ReadLine()
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
                    var element = stack.Pop();

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
