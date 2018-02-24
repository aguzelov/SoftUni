using System;

public class StartUp
{
    public static void Main()
    {
        string[] phoneNumbers = Console.ReadLine().Split();
        string[] sites = Console.ReadLine().Split();

        Smartphone smartphone = new Smartphone();

        foreach (string phone in phoneNumbers)
        {
            Console.WriteLine(smartphone.Calling(phone));
        }

        foreach (string url in sites)
        {
            Console.WriteLine(smartphone.Browsing(url));
        }
    }
}