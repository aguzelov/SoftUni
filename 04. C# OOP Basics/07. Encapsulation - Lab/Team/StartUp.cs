using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main(string[] args)
    {
        var lines = int.Parse(Console.ReadLine());
        var persons = new List<Person>();
        for (int i = 0; i < lines; i++)
        {
            var cmdArgs = Console.ReadLine().Split();
            var person = new Person(cmdArgs[0],
                                    cmdArgs[1],
                                    int.Parse(cmdArgs[2]),
                                    decimal.Parse(cmdArgs[3]));

            persons.Add(person);
        }

        Team team = new Team("SoftUni");
        foreach (Person person in persons)
        {
            team.AddPlayer(person);
        }

        Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
        Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
    }
}