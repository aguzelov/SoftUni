using System;

public class StartUp
{
    public static void Main()
    {
        string driver = Console.ReadLine();
        ICar car = new Ferrari(driver);

        Console.WriteLine(car.ToString());
    }
}