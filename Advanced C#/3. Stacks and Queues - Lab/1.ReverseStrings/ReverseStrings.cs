using System;
using System.Collections.Generic;

class ReverseStrings
{
    static void Main()
    {
        char[] inputAsChar = Console.ReadLine().Trim().ToCharArray();

        Stack<char> stack = new Stack<char>(inputAsChar);

        Console.WriteLine(string.Join("", stack));
    }
}
