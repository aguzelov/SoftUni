using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SoftUniKaraoke
{
    class SoftUniKaraoke
    {
        private static List<string> participants = new List<string>();

        private static List<string> songs = new List<string>();

        private static Dictionary<string, List<string>> awards = new Dictionary<string, List<string>>();

        private static void AddAwards(string participant, string award)
        {
            if (awards.ContainsKey(participant))
            {
                if (!awards[participant].Contains(award))
                {
                    awards[participant].Add(award);
                }
            }
            else
            {
                awards.Add(participant, new List<string> { award });
            }
        }

        private static bool TakeStagePerformance()
        {
            string input = Console.ReadLine();
            if (input == "dawn")
            {
                Print();
                return false;
            }

            string performancePattern = @"(^)(?<participant>.+?)\,\s+(?<song>.+)\,\s+(?<award>.+)($)";
            Match performance = Regex.Match(input, performancePattern);

            string participant = "";
            string song = "";
            string award = "";

            if (performance.Success)
            {
                participant = performance.Groups["participant"].Value;
                song = performance.Groups["song"].Value;
                award = performance.Groups["award"].Value;
            }

            if (!participants.Contains(participant) || !songs.Contains(song) || award == "")
            {
                return true;
            }
            else
            {
                AddAwards(participant, award);
            }

            return true;
        }

        private static void Print()
        {
            var sorted = awards.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(k => k.Key, v => v.Value);

            if (sorted.Count == 0)
            {
                Console.WriteLine("No awards");
                return;
            }

            foreach (var pair in sorted)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value.Count} awards");
                foreach (var awad in pair.Value.OrderBy(x => x).ToList())
                {
                    Console.WriteLine($"--{awad}");
                }
            }

        }

        static void Main(string[] args)
        {
            participants = Console.ReadLine()
                                  .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                  .ToList();


            string songPattern = @"(^|(?<=\s))\s*(?<song>.+?)($|(?=\,))";
            songs = Regex.Matches(Console.ReadLine(), songPattern).Cast<Match>()
                                                                 .Select(a => a.Groups["song"].Value)
                                                                 .ToList();

            while (TakeStagePerformance())
            {

            }

        }
    }
}
