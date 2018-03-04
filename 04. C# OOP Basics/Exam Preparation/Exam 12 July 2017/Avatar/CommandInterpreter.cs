using System;
using System.Linq;

public class CommandInterpreter
{
    private NationsBuilder nationsBuilder;

    public CommandInterpreter(NationsBuilder builder)
    {
        this.nationsBuilder = builder;
    }

    public void Execute()
    {
        while (true)
        {
            string[] inputArgs = Console.ReadLine().Split();
            string command = inputArgs[0];
            switch (command)
            {
                case "Bender":
                    this.nationsBuilder.AssignBender(inputArgs.Skip(1).ToList());
                    break;

                case "Monument":
                    this.nationsBuilder.AssignMonument(inputArgs.Skip(1).ToList());
                    break;

                case "Status":
                    string nationsType = inputArgs[1];
                    string result = this.nationsBuilder.GetStatus(nationsType);
                    Console.Write(result);
                    break;

                case "War":
                    nationsType = inputArgs[1];
                    this.nationsBuilder.IssueWar(nationsType);
                    break;

                case "Quit":
                    result = this.nationsBuilder.GetWarsRecord();
                    Console.Write(result);
                    return;
            }
        }
    }
}