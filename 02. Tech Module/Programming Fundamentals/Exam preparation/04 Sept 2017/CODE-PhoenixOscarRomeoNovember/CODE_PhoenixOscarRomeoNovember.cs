using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_PhoenixOscarRomeoNovember
{
    class CODE_PhoenixOscarRomeoNovember
    {
        private static Dictionary<string, List<string>> creatureAndSquads = new Dictionary<string, List<string>>();

        static void Main(string[] args)
        {
            while (TakeLine()) { }
        }

        private static bool TakeLine()
        {
            string input = Console.ReadLine();
            if (input == "Blaze it!")
            {
                Print();
                return false;
            }

            string[] array = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            string creature = array[0];
            string squadMate = array[1];
            if (creature == squadMate)
            {
                return true;
            }

            AddCreatureAndSquadMate(creature, squadMate);

            return true;
        }

        private static void AddCreatureAndSquadMate(string creature, string squadMate)
        {

            if (creatureAndSquads.ContainsKey(creature))
            {
                if (creatureAndSquads[creature].Contains(squadMate))
                {
                    return;
                }
                creatureAndSquads[creature].Add(squadMate);
            }
            else
            {
                creatureAndSquads.Add(creature, new List<string> { squadMate });
            }
        }

        private static void Print()
        {
            List<KeyValuePair<string, string>> toRemove = new List<KeyValuePair<string, string>>();

            foreach (var pair in creatureAndSquads)
            {
                foreach (string mate in pair.Value)
                {
                    if (creatureAndSquads.ContainsKey(mate))
                    {
                        if (creatureAndSquads[mate].Contains(pair.Key))
                        {
                            toRemove.Add(new KeyValuePair<string, string>(pair.Key, mate));
                        }
                    }
                }
            }

            foreach (var pair in toRemove)
            {
                creatureAndSquads[pair.Key].Remove(pair.Value);
            }


            foreach (var pair in creatureAndSquads.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{pair.Key} : {pair.Value.Count}");
            }
        }
    }
}
