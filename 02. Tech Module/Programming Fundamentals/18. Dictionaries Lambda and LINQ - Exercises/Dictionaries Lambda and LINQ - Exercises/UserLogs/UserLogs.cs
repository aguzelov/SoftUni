using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogs
{
    class UserLogs
    {
        static Dictionary<string, Dictionary<string, int>> log = new Dictionary<string, Dictionary<string, int>> { };

        static bool TakeInput()
        {
            string[] input = Console.ReadLine()
                            .Split(' ')
                            .Where(p => !string.IsNullOrWhiteSpace(p))
                            .ToArray();

            if (input[0] == "end")
            {
                PrintLog();
                return false;
            }

            string ip = TakeValidIP(input[0]);
            string name = TakeValidName(input[2]);

            if (log.ContainsKey(name))
            {
                if (log[name].ContainsKey(ip))
                {
                    log[name][ip] += 1;
                }
                else
                {
                    log[name].Add(ip, 1);
                }
            }
            else
            {

                log.Add(name, new Dictionary<string, int>());
                log[name].Add(ip, 1);
            }

            return true;
        }

        static void PrintLog()
        {
            var orderedLog = log.OrderBy(p => p.Key);

            foreach (KeyValuePair<string, Dictionary<string, int>> names in orderedLog)
            {
                string name = names.Key;
                Console.WriteLine(name + ":");
                Dictionary<string, int> pair = log[name];

                Console.Write(string.Join(", ", pair.Select(x => x.Key + " => " + x.Value).ToArray()));

                Console.WriteLine(".");
            }
        }

        static string TakeValidIP(string text)
        {
            text = text.Remove(0, 3);
            return text;
        }

        static string TakeValidName(string text)
        {
            text = text.Remove(0, 5);
            return text;
        }

        static void Main(string[] args)
        {
            while (TakeInput())
            {

            }
        }
    }
}
