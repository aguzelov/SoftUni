using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkProjects
{
    class TeamworkProjects
    {
        public static int countOfTeam;

        public static List<Team> teams = new List<Team>();

        public static bool TakeInput()
        {
            string[] input = Console.ReadLine()
                                    .Split('-')
                                    .Where(p => !string.IsNullOrWhiteSpace(p))
                                    .ToArray();

            if (input[0] == "end of assignment")
            {
                return false;
            }
            

            string user = input[0];
            string team = input[1];

            
            if (team.ElementAt(0) != '>') // creat team. [0] team lider / [1] team name 
            {
                if(teams.Count >= countOfTeam)
                {
                    return true;
                }

                if (teams.Any(x => x.Name == team)) //If user tries to create a team more than once
                {
                    Console.WriteLine($"Team {team} was already created!");
                }
                else if (teams.Any(x => x.Creator == user)) //Creator of a team cannot create another team
                {
                    Console.WriteLine($"{user} cannot create another team!");
                }
                else
                {
                    teams.Add(new Team(user, team));
                    Console.WriteLine($"Team {team} has been created by {user}!");
                }
            }
            else // add member. [0] member / [1] to team
            {
                team = input[1].Remove(0, 1); 

                if (teams.Any(x => x.Name == team))
                {
                    if (teams.Any(x => x.Members.Any(m => m == user)) || 
                        teams.Any(c => c.Creator == user)) // Member of a team cannot join another team
                    {
                        Console.WriteLine($"Member {user} cannot join team {team}!");
                    }
                    else
                    {
                        int index = teams.FindIndex(x => x.Name == team);
                        teams[index].AddMembers(user);
                    }
                }
                else //If user tries to join currently non - existing team
                {
                    Console.WriteLine($"Team {team} does not exist!");
                }
            }
            
            return true;
        }

        static void Main(string[] args)
        {
            countOfTeam = int.Parse(Console.ReadLine());

            while (TakeInput())
            {
            }

            foreach(Team team in teams.Where(u => u.Members.Count>0).OrderByDescending(x=> x.Members.Count).ThenBy(x=>x.Name))
            {
                Console.WriteLine($"{team.Name}");
                Console.WriteLine($"- {team.Creator}");
                foreach(string user in team.Members.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {user}");
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach (Team disband in teams.Where(d => d.Members.Count == 0).OrderBy(x => x.Name))
            {
                Console.WriteLine(disband.Name);
            }
        }
    }

    class Team
    {
        private string name;
        private string creator;
        private List<string> members = new List<string>();

        public string Name { get => name; set => name = value; }
        public string Creator { get => creator; set => creator = value; }
        public List<string> Members { get => members; set => members = value; }

        public Team(string creator, string name)
        {
            this.name = name;
            this.creator = creator;
        }

        public void AddMembers(string memberName)
        {
            members.Add(memberName);
        }

    }
}
