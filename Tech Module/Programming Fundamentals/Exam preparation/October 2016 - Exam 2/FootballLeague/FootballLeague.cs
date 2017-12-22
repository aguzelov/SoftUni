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
        private static Dictionary<string, long> points = new Dictionary<string, long>();

        private static Dictionary<string, long> goals = new Dictionary<string, long>();

        private static string key;

        private static void SetPoints(string team, long point)
        {
            if (points.ContainsKey(team))
            {
                points[team] += point;
            }
            else
            {
                points.Add(team, point);
            }
        }

        private static void SetGoals(string team, long score)
        {
            if (goals.ContainsKey(team))
            {
                goals[team] += score;
            }
            else
            {
                goals.Add(team, score);
            }
        }

        private static void Add(string teamA, string teamB, long scoreA, long scoreB)
        {
            SetGoals(teamA, scoreA);
            SetGoals(teamB, scoreB);

            if (scoreA > scoreB)
            {
                SetPoints(teamA, 3);
                SetPoints(teamB, 0);
            }
            else if (scoreA < scoreB)
            {
                SetPoints(teamA, 0);
                SetPoints(teamB, 3);
            }
            else
            {
                SetPoints(teamA, 1);
                SetPoints(teamB, 1);
            }
        }

        private static void Print()
        {
            int counter = 1;
            Console.WriteLine("League standings:");
            foreach (var pair in points.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{counter}. {pair.Key} {pair.Value}");
                counter++;
            }

            Console.WriteLine("Top 3 scored goals:");
            foreach (var pair in goals.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(3))
            {
                Console.WriteLine($"- {pair.Key} -> {pair.Value}");
            }
        }

        private static string GetTeamName(string name)
        {
            string pattern = $"^(.*?)([{key}]+)(?<team>.+?)([{key}]+)(.*?)$";


            int index = name.IndexOf(key);
            name = name.Remove(0, index+key.Length);

            index = name.IndexOf(key);
            name = name.Remove(index,name.Length - index);

            char[] charArray = name.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray).ToUpper();
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
            
            string teamA = GetTeamName(array[0]);
            string teamB = GetTeamName(array[1]);

            long[] teamsScore = array[array.Length - 1].Split(':').Select(long.Parse).ToArray();

            long teamAScore = teamsScore[0];
            long teamBscore = teamsScore[1];

            Add(teamA, teamB, teamAScore, teamBscore);

            return true;
        }

        static void Main(string[] args)
        {
            key = Console.ReadLine();

            while (TakeInput()) { }
        }
    }
}
