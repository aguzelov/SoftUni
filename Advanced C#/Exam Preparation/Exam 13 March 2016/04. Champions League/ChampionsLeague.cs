using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public class ChampionsLeague
{
    private static Dictionary<string, int> winsByTeam = new Dictionary<string, int>();
    private static Dictionary<string, List<string>> opponentsByTeam = new Dictionary<string, List<string>>();

    public static void Main()
    {
        string input = string.Empty;
        while ((input = Console.ReadLine()) != "stop")
        {
            string[] inputArray = input
                .Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim())
                .ToArray();

            string firstTeam = inputArray[0];
            string secondTeam = inputArray[1];

            int[] goals = inputArray[2].Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstTeamGoals = goals[0];
            int secondTeamGoalsOnAwaySoil = goals[1];

            goals = inputArray[3].Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int secondTeamGoals = goals[0];
            int firstTeamGoalOnAwaySoil = goals[1];


            int firstTeamTotalGoals = firstTeamGoals + firstTeamGoalOnAwaySoil;
            int secondTeamTotalGoals = secondTeamGoals + secondTeamGoalsOnAwaySoil;

            if (firstTeamTotalGoals > secondTeamTotalGoals)
            {
                AddTeam(firstTeam, true);
                AddTeam(secondTeam, false);
                AddOpponent(firstTeam, secondTeam);

            }
            else if (secondTeamTotalGoals > firstTeamTotalGoals)
            {
                AddTeam(secondTeam, true);
                AddTeam(firstTeam, false);
                AddOpponent(secondTeam, firstTeam);
            }
            else
            {
                if (firstTeamGoalOnAwaySoil > secondTeamGoalsOnAwaySoil)
                {
                    AddTeam(firstTeam, true);
                    AddTeam(secondTeam, false);
                    AddOpponent(firstTeam, secondTeam);
                }
                else if (secondTeamGoalsOnAwaySoil > firstTeamGoalOnAwaySoil)
                {
                    AddTeam(secondTeam, true);
                    AddTeam(firstTeam, false);
                    AddOpponent(secondTeam, firstTeam);
                }
            }


        }
        Print();
    }

    private static void Print()
    {
        foreach (var pair in winsByTeam.OrderByDescending(p => p.Value).ThenBy(n => n.Key))
        {
            Console.WriteLine($"{pair.Key}");
            Console.WriteLine($"- Wins: {pair.Value}");
            Console.WriteLine($"- Opponents: {string.Join(", ", opponentsByTeam[pair.Key].OrderBy(n => n))}");
        }
    }

    private static void AddOpponent(string first, string second)
    {
        if (!opponentsByTeam.ContainsKey(first))
        {
            opponentsByTeam.Add(first, new List<string>());
        }

        opponentsByTeam[first].Add(second);

        if (!opponentsByTeam.ContainsKey(second))
        {
            opponentsByTeam.Add(second, new List<string>());
        }

        opponentsByTeam[second].Add(first);
    }

    private static void AddTeam(string team, bool isWinner)
    {
        if (!winsByTeam.ContainsKey(team))
        {
            winsByTeam.Add(team, 0);
        }

        if (isWinner) winsByTeam[team]++;
    }
}