using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        Spy spy = new Spy();
        string result = spy.CollectGettersAndSetters("Hacker");
        Console.WriteLine(result);
    }
}