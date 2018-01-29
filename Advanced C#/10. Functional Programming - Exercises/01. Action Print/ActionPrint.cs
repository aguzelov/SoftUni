using System;
public class ActionPrint
{
    public static void Main()
    {
        Action<string> action = (n) => Console.WriteLine(n);

        foreach (var name in Console.ReadLine().Split(' '))
        {
            action(name);
        }
    }
}
