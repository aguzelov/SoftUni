using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;

public class RecursiveFibonacci
{
    private static long[] _memo;

    public static void Main()
    {
        // ReSharper disable once AssignNullToNotNullAttribute
        var n = int.Parse(Console.ReadLine());

        _memo = new long[n+1];

        Console.WriteLine(GetFibonacci(n));

    }

    public static long GetFibonacci(long n)
    {
        if (n <= 2)
            return 1;

        if (_memo[n] != 0)
            return _memo[n];


        _memo[n] = GetFibonacci(n - 1) + GetFibonacci(n - 2);
        return _memo[n];
    }
}