using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague
{
    class FootballLeague
    {
        private static string key;

        private static Dictionary<string, long> league = new Dictionary<string, long>();

        private static Dictionary<string, long> goals = new Dictionary<string, long>();

        static void Main(string[] args)
        {
            key = Console.ReadLine();

            while (TakeInput()) { }

            Print();
        }

        private static void Print()
        {
            Console.WriteLine("League standings:");
            int count = 1;
            foreach (var pair in league.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{count}. {pair.Key} {pair.Value}");
                count++;
            }

            Console.WriteLine("Top 3 scored goals:");
            foreach (var pair in goals.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(3).ToDictionary(k => k.Key, v => v.Value))
            {
                Console.WriteLine($"- {pair.Key} -> {pair.Value}");
            }
        }

        private static bool TakeInput()
        {
            string input = Console.ReadLine();
            if (input == "final")
            {
                return false;
            }

            string[] results = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string teamAName = GetName(results[0]);
            string teamBName = GetName(results[1]);
            string[] goals = results[results.Length - 1].Trim().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            long teamAGoal = GetScore(goals[0]);
            long teamBGoal = GetScore(goals[1]);

            AddGuals(teamAName, teamAGoal);
            AddGuals(teamBName, teamBGoal);

            GetPoints(teamAName, teamBName, teamAGoal, teamBGoal);

            return true;
        }

        private static void GetPoints(string teamAName, string teamBName, long teamAGoal, long teamBGoal)
        {
            long scoreA = 0;
            long scoreB = 0;

            if (teamAGoal > teamBGoal)
            {
                scoreA = 3;
                scoreB = 0;
            }
            else if (teamBGoal > teamAGoal)
            {
                scoreB = 3;
                scoreA = 0;
            }
            else
            {
                scoreA = 1;
                scoreB = 1;
            }

            AddToLeague(teamAName, scoreA);
            AddToLeague(teamBName, scoreB);
        }

        private static void AddToLeague(string teamName, long score)
        {
            if (league.ContainsKey(teamName))
            {
                league[teamName] += score;
            }
            else
            {
                league.Add(teamName, score);
            }
        }

        private static void AddGuals(string teamAName, long teamAGoal)
        {
            if (goals.ContainsKey(teamAName))
            {
                goals[teamAName] += teamAGoal;
            }
            else
            {
                goals.Add(teamAName, teamAGoal);
            }
        }

        private static long GetScore(string v)
        {
            long score = long.Parse(v);
            return score;
        }

        private static string GetName(string name)
        {
            name = name.Trim();
            int index = name.IndexOf(key);
            name = name.Remove(0, index + key.Length);

            index = name.LastIndexOf(key);
            name = name.Remove(index, name.Length - index);

            char[] array = name.ToCharArray();
            Array.Reverse(array);

            return new string(array).ToUpper();
        }
    }
}
