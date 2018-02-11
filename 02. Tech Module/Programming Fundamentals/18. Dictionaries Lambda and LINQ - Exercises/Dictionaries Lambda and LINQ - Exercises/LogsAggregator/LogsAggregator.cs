using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsAggregator
{
    class LogsAggregator
    {
        static List<User> users = new List<User>();

        static void Report()
        {
            foreach (User user in users.OrderBy(x => x.Name).ToList())
            {
                user.Report();
            }
        }

        static bool TakeInput()
        {
            //<IP> <user> <duration>
            string[] log = Console.ReadLine()
                                  .Split(' ')
                                  .Where(p => !string.IsNullOrWhiteSpace(p))
                                  .ToArray();

            string ip = log[0];
            string user = log[1];
            int duration = int.Parse(log[2]);

            if (users.Any(x => x.Name == user))
            {
                User currentUser = users.FirstOrDefault(u => u.Name == user);
                currentUser.AddIp(ip, duration);
            }
            else
            {
                users.Add(new User(user, ip, duration));
            }

            return true;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                TakeInput();
            }
            Report();
        }
    }

    class User
    {
        private string name;
        private List<string> ips = new List<string>();
        private int totalDuration;

        public User(string name)
        {
            this.name = name;
            this.totalDuration = 0;
        }

        public User(string name, string ip, int duration)
        {
            this.name = name;
            this.totalDuration = 0;
            AddIp(ip, duration);
        }

        public int TotalDuration { get => totalDuration; }
        public string Name { get => name; set => name = value; }

        public void AddIp(string ip, int duration)
        {
            this.totalDuration += duration;

            if (!ips.Contains(ip))
            {
                ips.Add(ip);
            }
        }

        public void Report()
        {
            var sortedIp = ips.OrderBy(x => x).ToList();
            Console.WriteLine($"{this.name}: {this.totalDuration} [{string.Join(", ", sortedIp)}]");
        }
    }
}
