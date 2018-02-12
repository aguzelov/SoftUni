using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var accounts = new Dictionary<int, BankAccount>();

        var input = string.Empty;

        while ((input = Console.ReadLine()) != "End")
        {
            var commandArgs = input.Split();

            var cmdType = commandArgs[0];

            switch (cmdType)
            {
                case "Create":
                    Create(commandArgs, accounts);
                    break;
                case "Deposit":
                    Deposit(commandArgs, accounts);
                    break;
                case "Withdraw":
                    Withdraw(commandArgs, accounts);
                    break;
                case "Print":
                    Print(commandArgs, accounts);
                    break;
            }
        }
    }

    private static void Print(string[] commandArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(commandArgs[1]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine($"Account does not exist");
            return;
        }

        Console.WriteLine(accounts[id].ToString());
    }

    private static void Withdraw(string[] commandArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(commandArgs[1]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine($"Account does not exist");
            return;
        }

        var amount = decimal.Parse(commandArgs[2]);

        if (accounts[id].Balance - amount < 0)
        {
            Console.WriteLine("Insufficient balance");
            return;
        }

        accounts[id].Withdraw(amount);
    }

    private static void Deposit(string[] commandArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(commandArgs[1]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine($"Account does not exist");
            return;
        }

        var amount = decimal.Parse(commandArgs[2]);
        accounts[id].Deposit(amount);
    }

    private static void Create(string[] commandArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(commandArgs[1]);
        if (accounts.ContainsKey(id))
        {
            Console.WriteLine($"Account already exists");
        }
        else
        {
            accounts.Add(id, new BankAccount(id));
        }
    }
}