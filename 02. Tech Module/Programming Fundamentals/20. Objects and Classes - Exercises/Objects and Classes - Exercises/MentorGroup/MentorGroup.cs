using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorGroup
{
    class MentorGroup
    {
        static bool AddUsers()
        {
            string[] input = Console.ReadLine()
                                    .Split(' ')
                                    .ToArray();
            if(input[0] == "end")
            {
                return false;
            }

            string name = input[0];

            if (input.Length > 1)
            {
                DateTime[] dates = input[1]
                                    .Split(',')
                                    .Select(d => DateTime.ParseExact(d, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                                    .ToArray();

                Users.AddUserDate(name, dates);
            }
            else
            {
                Users.AddUser(name);
            }
            

            

            return true;
        }

        static bool AddComments()
        {
            string[] input = Console.ReadLine()
                                    .Split('-')
                                    .ToArray();
            
            if(input[0] == "end of comments")
            {
                return false;
            }

            string name = input[0];
            string comment = input[1];

            Users.AddUserComment(name, comment);

            return true;
        }

        static void Main(string[] args)
        {
            while (AddUsers()) { }
            while (AddComments()) { }
            Users.PrintInfo();
        }
    }
    class Users
    {
        private static List<string> users = new List<string>();
        private static Dictionary<string, List<DateTime>> userDates = new Dictionary<string, List<DateTime>> { };
        private static Dictionary<string, List<string>> userComments = new Dictionary<string, List<string>> { };

        public static void AddUser(string name)
        {
            if (!userDates.ContainsKey(name))
            {
                userDates.Add(name, new List<DateTime>());
                
                users.Add(name);
                userComments.Add(name, new List<string>());
            }
        }

        public static void AddUserDate(string name, DateTime[] dates)
        {
            if (userDates.ContainsKey(name))
            {
                foreach (DateTime date in dates)
                {
                    userDates[name].Add(date);
                }
            }
            else
            {
                userDates.Add(name, new List<DateTime>());
                foreach(DateTime date in dates)
                {
                    userDates[name].Add(date);
                }
                users.Add(name);
                userComments.Add(name, new List<string>());
            }
        }

        public static void AddUserComment(string name, string comment)
        {
            if (userComments.ContainsKey(name))
            {
                userComments[name].Add(comment);
            }
        }

        public static void PrintInfo()
        {
            //{ user}
            //Comments:
            //- { firstComment} 
            //…
            //Dates attended:
            //-- { firstDate}
            //-- { secondDate}

            foreach(string user in users.OrderBy(x=> x))
            {
                Console.WriteLine(user);
                Console.WriteLine("Comments:");
                foreach(string comment in userComments[user])
                {
                    Console.WriteLine($"- {comment}");
                }
                Console.WriteLine("Dates attended:");
                foreach(DateTime date in userDates[user].OrderBy(x=> x).ToList())
                {
                    Console.WriteLine($"-- {date.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture)}");
                }
            }

        }

    }
}
