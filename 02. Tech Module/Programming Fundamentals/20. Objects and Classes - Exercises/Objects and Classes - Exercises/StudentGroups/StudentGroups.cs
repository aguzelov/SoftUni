using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGroups
{
    class StudentGroups
    {
        static List<Town> towns = new List<Town>();

        static bool TakeInput()
        {
            string input = Console.ReadLine();
            if (input == "End") { return false; }
            
            if (input.Contains("=>"))
            {
                string[] town = input.Split(new char[] { '=', '>' })
                                     .Select(p => p.Trim())
                                     .Where(p => !string.IsNullOrWhiteSpace(p))
                                     .ToArray();
                string name = town[0];
                string capacity = town[1].Split(' ').ToArray().ElementAt(0);

                towns.Add(new Town(name, capacity));
            }
            else
            {
                string[] student = input.Split(new char[] { '|' })
                                      .Where(p => !string.IsNullOrWhiteSpace(p))
                                      .Select(p => p.Trim())
                                      .ToArray();

                Town lastTown = towns.Last();
                lastTown.AddStudent(student);
            }

            return true;
        }

        static void Main(string[] args)
        {
            while (TakeInput()) { }

            int groupCounter = 0;
            int townCounter = towns.Count; 
            foreach(Town town in towns)
            {
                town.SortByEmail();
                groupCounter += town.Groups.Last().Key;
                
            }
            Console.WriteLine($"Created {groupCounter} groups in {townCounter} towns:");
            foreach (Town town in towns.OrderBy(n => n.Name))
            {
                foreach (KeyValuePair<int, List<string>> group in town.Groups)
                {
                    Console.Write($"{town.Name} => ");
                    Console.WriteLine(string.Join(", ", group.Value));
                }
            }
        }
    }

    class Town
    {
        private string name;
        private int capacity;

        List<Student> students = new List<Student>();

        Dictionary<int, List<string>> groups = new Dictionary<int, List<string>> {
            {1, new List<string>() }
        };

        public Town(string name, string capacity)
        {
            this.name = name;
            this.capacity = int.Parse(capacity);
        }

        public string Name { get => name; set => name = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public Dictionary<int, List<string>> Groups { get => groups; set => groups = value; }
        internal List<Student> Strudents { get => students; set => students = value; }

        public void AddStudent(string[] studentInfo)
        {
            string name = studentInfo[0];
            string email = studentInfo[1];
            DateTime date = DateTime.ParseExact(studentInfo[2], "d-MMM-yyyy", CultureInfo.InvariantCulture);
            students.Add(new Student(name, email, date));
        }

        public void SortByEmail()
        {
            List<string> emails = students.OrderBy(d => d.RegistrationDate).ThenBy(n => n.Name).ThenBy(e => e.Email).Select(x => x.Email).ToList();

            int key = groups.First().Key;

            for (int i = 0; i < emails.Count; i++)
            {
                if (groups[key].Count < this.capacity)
                {
                    groups[key].Add(emails[i]);
                }
                else
                {
                    key++;
                    groups.Add(key, new List<string>());
                    groups[key].Add(emails[i]);
                }
            }

        }
    }

    class Student
    {
        private string name;
        private string email;
        private DateTime registrationDate;

        public Student(string name, string email, DateTime registrationDate)
        {
            this.name = name;
            this.email = email;
            this.registrationDate = registrationDate;
        }

        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public DateTime RegistrationDate { get => registrationDate; set => registrationDate = value; }

    }
}
