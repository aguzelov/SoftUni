using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        Spy spy = new Spy();
        string result = spy.RevealPrivateMethods("Hacker");
        Console.WriteLine(result);
    }
}