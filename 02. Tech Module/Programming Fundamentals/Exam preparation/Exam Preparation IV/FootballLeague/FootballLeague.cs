using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FootballLeague
{
    class FootballLeague
    {
        private static string key = null;

        private static Dictionary<string, List<long>> teams = new Dictionary<string, List<long>>();

        private static void EditOrAddTeamInfo(string teamName, long teamGoals,long teamScore)
        {
            if (teams.ContainsKey(teamName))
            {
                teams[teamName][0] += teamGoals;
                teams[teamName][1] += teamScore;
            }
            else
            {
                teams.Add(teamName, new List<long>());
                teams[teamName].Add(teamGoals);
                teams[teamName].Add(teamScore);
            }
        }

        private static bool TakeInput()
        {
            string input = Console.ReadLine();

            if (input == "final")
            {
                Print();
                return false;
            }

            string[] array = input.Split(' ').ToArray();

            string teamAName = GetTeamName(array[0]);

            string teamBName = GetTeamName(array[1]);

            GetScores(array[2], out long teamAScore, out long teamAGoals, out long teamBScore, out long teamBGoals);

            //edit or add teamA
            EditOrAddTeamInfo(teamAName, teamAGoals, teamAScore);
            EditOrAddTeamInfo(teamBName, teamBGoals, teamBScore);

            return true;
        }

        private static string GetTeamName(string text)
        {
            int frontIndex = text.IndexOf(key);
            int frontCount = frontIndex + key.Length;

            int lastIndex = text.LastIndexOf(key);
            
            string teamName = text.Substring(frontCount, lastIndex - frontIndex - key.Length);
            
            char[] charArray = teamName.ToCharArray();
            Array.Reverse(charArray);
            teamName = new string(charArray);

            return teamName.ToUpper();
        }

        private static void GetScores(string text, out long teamAScore, out long teamAGoals, out long teamBScore, out long teamBGoals)
        {
            long[] goals = text.Split(':').Select(long.Parse).ToArray();

            teamAGoals = goals[0];
            teamBGoals = goals[1];

            if (teamAGoals > teamBGoals)
            {
                teamAScore = 3;
                teamBScore = 0;
            }
            else if (teamAGoals < teamBGoals)
            {
                teamAScore = 0;
                teamBScore = 3;
            }
            else
            {
                teamAScore = 1;
                teamBScore = 1;
            }

        }

        private static void Print()
        {
            int place = 1;
            Console.WriteLine("League standings:");
            foreach (var pair in teams.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{place}. {pair.Key} {pair.Value[1]}");
                place++;
            }

            Console.WriteLine("Top 3 scored goals:");
            
            foreach (var pair in teams.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key).Take(3))
            {
                Console.WriteLine($"- {pair.Key} -> {pair.Value[0]}");
            }
        }

        static void Main(string[] args)
        {
            key = Console.ReadLine();

            while (TakeInput()) { }
        }
    }

}
