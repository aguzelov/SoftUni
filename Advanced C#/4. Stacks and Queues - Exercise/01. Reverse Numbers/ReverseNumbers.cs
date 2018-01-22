using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class ReverseNumbers
{
    static void Main()
    {
        List<int> input = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        Stack<int> stack = new Stack<int>(input);

        Console.WriteLine(string.Join(" " , stack));
    }
}

