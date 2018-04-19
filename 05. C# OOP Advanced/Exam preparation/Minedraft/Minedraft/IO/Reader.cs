using System;

public class Reader : IReader
{
    public string ReadLine()
    {
        string result = Console.ReadLine().Trim();
        return result;
    }
}