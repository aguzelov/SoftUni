using System;

public class StartUp
{
    private static void Main(string[] args)
    {
        string[] inputArgs = Console.ReadLine().Split();

        string item1 = inputArgs[0] + " " + inputArgs[1];
        string item2 = inputArgs[2];

        Truple<string, string> firstTruple = new Truple<string, string>(item1,item2);

        inputArgs = Console.ReadLine().Split();
        string personName = inputArgs[0];
        int beerAmount = int.Parse(inputArgs[1]);

        Truple<string,int> secondTruple = new Truple<string, int>(personName, beerAmount);

        inputArgs = Console.ReadLine().Split();
        int firstNum = int.Parse(inputArgs[0]);
        double secondNum = double.Parse(inputArgs[1]);

        Truple<int,double> thirdTruple = new Truple<int, double>(firstNum, secondNum);

        Console.WriteLine(firstTruple);
        Console.WriteLine(secondTruple);
        Console.WriteLine(thirdTruple);
    }
}