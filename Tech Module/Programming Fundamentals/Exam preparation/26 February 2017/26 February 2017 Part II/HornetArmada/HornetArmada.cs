using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HornetArmada
{
    class HornetArmada
    {
        private static Dictionary<string, Legion> legions = new Dictionary<string, Legion>();

        private static void Add(int lastActivity, string legion, string soldier, long count)
        {

            if (legions.ContainsKey(legion))
            {
                legions[legion].AddSoldiers(lastActivity, soldier, count);
            }
            else
            {
                legions.Add(legion, new Legion(legion, lastActivity, soldier, count));
            }
        }

        private static void Validate(string input)
        {
            string[] array = input.Split(new char[] { '=', ' ', ':', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int lastActivity = int.Parse(array[0]);
            string legion = array[1];
            string soldier = array[2];
            long count = long.Parse(array[3]);
            Add(lastActivity, legion, soldier, count);
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Validate(input);
            }

            string line = Console.ReadLine();
            if (line.Contains("\\"))
            {
                string[] firstCase = line.Split('\\').ToArray();
                int lastActivity = int.Parse(firstCase[0]);
                string soldier = firstCase[1];

                var sorted = legions.Where(x => x.Value.LastActivity < lastActivity).ToDictionary(x => x.Key, x => x.Value);

                Dictionary<string, long> found = new Dictionary<string, long>();

                foreach (var legion in sorted)
                {
                    if (legion.Value.Soldiers.ContainsKey(soldier))
                        found.Add(legion.Value.Name, legion.Value.Soldiers[soldier]);
                }
                foreach (var legion in found.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"{legion.Key} -> {legion.Value}");
                }

            }
            else
            {
                var sorted = legions.Where(x => x.Value.Soldiers.ContainsKey(line)).ToDictionary(x => x.Key, x => x.Value);

                foreach (var legion in sorted.OrderByDescending(x => x.Value.LastActivity))
                {

                    legion.Value.PrintInfo();
                }

            }
        }
    }

    class Legion
    {
        private string name;
        private int lastActivity = int.MinValue;
        private Dictionary<string, long> soldiers = new Dictionary<string, long>();

        public Legion(string name, int lastActivity, string soldierType, long count)
        {
            this.name = name;
            AddSoldiers(lastActivity, soldierType, count);
        }

        public string Name { get => name; set => name = value; }
        public int LastActivity { get => lastActivity; set => lastActivity = value; }
        public Dictionary<string, long> Soldiers { get => soldiers; set => soldiers = value; }

        public void AddSoldiers(int lastActivity, string soldier, long count)
        {
            if (this.lastActivity < lastActivity)
            {
                this.lastActivity = lastActivity;
            }

            if (soldiers.ContainsKey(soldier))
            {
                soldiers[soldier] += count;
            }
            else
            {
                soldiers.Add(soldier, count);
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{this.lastActivity} : {this.Name}");
        }
    }


}
