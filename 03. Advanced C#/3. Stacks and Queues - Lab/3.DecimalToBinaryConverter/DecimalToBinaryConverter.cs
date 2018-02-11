using System;
using System.Collections.Generic;

class DecimalToBinaryConverter
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        
        if(number == 0)
        {
            Console.WriteLine(0);
        }

        Stack<int> binary = new Stack<int>();

        while(number != 0)
        {
            binary.Push(number % 2);
            number /= 2;
        }

        Console.WriteLine(string.Join("", binary));

    }
}

