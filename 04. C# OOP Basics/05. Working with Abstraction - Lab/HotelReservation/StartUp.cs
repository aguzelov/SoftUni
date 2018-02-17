using System;
public class StartUp
    {
       public static void Main()
        {
        PriceCalculator priceCalculator = new PriceCalculator(Console.ReadLine);

        Console.WriteLine(priceCalculator.ToString());
        }
    }
