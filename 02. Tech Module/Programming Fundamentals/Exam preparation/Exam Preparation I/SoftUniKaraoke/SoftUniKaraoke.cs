using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniKaraoke
{
    class SoftUniKaraoke
    {
        static List<string> participants = new List<string>();
        static List<string> songs = new List<string>();

        static Dictionary<string, List<string>> performances = new Dictionary<string, List<string>> { };

        static void RecieveParticipants()
        {
            participants = Console.ReadLine()
                                  .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(p => p.Trim())
                                  .Where(p => !string.IsNullOrWhiteSpace(p))
                                  .ToList();
        }

        static void RecieveSongs()
        {
            songs = Console.ReadLine()
                           .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(p => p.Trim())
                           .Where(p => !string.IsNullOrWhiteSpace(p))
                           .ToList();
        }

        static void PrintAwards()
        {
            if (performances.Count == 0)
            {
                Console.WriteLine("No awards");
                return;
            }

            var sortedPerf = performances.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);

            foreach (var performance in sortedPerf)
            {
                Console.WriteLine($"{performance.Key}: {performance.Value.Count} awards");
                var sortedAward = performance.Value.OrderBy(x => x).ToList();

                foreach (string award in sortedAward)
                {
                    Console.WriteLine($"--{award}");
                }
            }
        }

        static bool TakePerformance()
        {
            string[] input = Console.ReadLine()
                                          .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(p => p.Trim())
                                          .Where(p => !string.IsNullOrWhiteSpace(p))
                                          .ToArray();

            if (input[0] == "dawn")
            {
                PrintAwards();
                return false;
            }

            string participant = input[0];
            string song = input[1];
            string award = input[2];

            if (participants.Contains(participant) && songs.Contains(song))
            {
                if (performances.ContainsKey(participant))
                {
                    if (!performances[participant].Contains(award))
                    {
                        performances[participant].Add(award);
                    }
                }
                else
                {
                    performances.Add(participant, new List<string>());
                    performances[participant].Add(award);
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            RecieveParticipants();

            RecieveSongs();

            while (TakePerformance()) { }

        }
    }
}
