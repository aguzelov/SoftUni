using System;
using System.Collections.Generic;
using System.Linq;

internal class StartUp
{
    private static void Main()
    {
        var teams = new List<Team>();

        while (true)
        {
            string[] input = Console.ReadLine().Split(new string[] { ";", " " }, StringSplitOptions.RemoveEmptyEntries);
            switch (input[0])
            {
                case "Team":
                    try
                    {
                        CreateTeam(teams, input[1]);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                    break;

                case "Add":
                    AddPlayer(teams, input);
                    break;

                case "Remove":
                    Remove(teams, input);
                    break;

                case "Rating":
                    GetRating(teams, input);
                    break;

                default:
                    return;
            }
        }
    }

    private static void GetRating(List<Team> teams, string[] input)
    {
        string teamName = input[1];

        if (!teams.Any(t => t.Name == teamName))
        {
            Console.WriteLine($"Team {teamName} does not exist.");
            return;
        }

        Team team = teams.FirstOrDefault(t => t.Name == teamName);

        Console.WriteLine(team);
    }

    private static void Remove(List<Team> teams, string[] input)
    {
        string teamName = input[1];

        if (!teams.Any(t => t.Name == teamName))
        {
            Console.WriteLine($"Team {teamName} does not exist.");
            return;
        }

        Team team = teams.FirstOrDefault(t => t.Name == teamName);

        string playerName = input[2];

        try
        {
            team.RemovePlayer(playerName);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void AddPlayer(List<Team> teams, string[] input)
    {
        string teamName = input[1];

        if (!teams.Any(t => t.Name == teamName))
        {
            Console.WriteLine($"Team {teamName} does not exist.");
            return;
        }

        Team team = teams.FirstOrDefault(t => t.Name == teamName);

        string playerName = input[2];
        int endurance = int.Parse(input[3]);
        int sprint = int.Parse(input[4]);
        int dribble = int.Parse(input[5]);
        int passing = int.Parse(input[6]);
        int shooting = int.Parse(input[7]);
        try
        {
            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
            team.AddPlayer(player);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void CreateTeam(List<Team> teams, string teamName)
    {
        teams.Add(new Team(teamName));
    }
}