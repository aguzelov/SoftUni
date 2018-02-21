using System;

public class StartUp
{
    static void Main()
    {
        string[] foods = Console.ReadLine().Split();

        Gandalf gandalf = new Gandalf();
        foreach(string food in foods)
        {
            gandalf.EatFood(food);
        }

        Console.WriteLine(gandalf);
    }
}
