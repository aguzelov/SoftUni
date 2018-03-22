using System;

public class StartUp
{
    private static void Main(string[] args)
    {
        string[] inputArgs = Console.ReadLine().Split();

        string item1 = inputArgs[0] + " " + inputArgs[1];
        string item2 = inputArgs[2];
        string item3 = inputArgs[3];

        Threeuple<string, string, string> firstTruple = 
            new Threeuple<string, string, string>(item1, item2, item3);

        inputArgs = Console.ReadLine().Split();
        string personName = inputArgs[0];
        int beerAmount = int.Parse(inputArgs[1]);
        bool drunkText = inputArgs[2] == "drunk" ? true : false;

        Threeuple<string, int, bool> secondTruple = 
            new Threeuple<string, int, bool>(personName, beerAmount, drunkText);

        inputArgs = Console.ReadLine().Split();
        string name = inputArgs[0];
        double balance = double.Parse(inputArgs[1]);
        string bankName = inputArgs[2];

        Threeuple<string, double, string> thirdTruple = 
            new Threeuple<string, double, string>(name, balance, bankName);

        Console.WriteLine(firstTruple);
        Console.WriteLine(secondTruple);
        Console.WriteLine(thirdTruple);
    }
}