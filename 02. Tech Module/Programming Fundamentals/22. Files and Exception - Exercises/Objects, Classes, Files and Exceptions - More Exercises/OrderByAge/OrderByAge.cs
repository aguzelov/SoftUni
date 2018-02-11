using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderByAge
{
    class OrderByAge
    {
        static List<Person> persons = new List<Person>();

        static bool TakeInput()
        {
            string input = Console.ReadLine();

            if (input.Equals("End"))
            {
                return false;
            }

            string[] personInfo = input.Split(' ')
                                       .Where(p => !string.IsNullOrWhiteSpace(p))
                                       .ToArray();

            string name = personInfo[0];
            string id = personInfo[1];
            int age = int.Parse(personInfo[2]);

            persons.Add(new Person(name, id, age));

            return true;
        }

        static void Main(string[] args)
        {
            while (TakeInput()) { }

            foreach (Person person in persons.OrderBy(a => a.Age))
            {
                Console.WriteLine($"{person.Name} with ID: {person.Id} is {person.Age} years old.");
            }
        }
    }

    class Person
    {
        private string name;
        private string id;
        private int age;

        public Person(string name, string id, int age)
        {
            this.name = name;
            this.id = id;
            this.age = age;
        }

        public string Name { get => name; set => name = value; }
        public string Id { get => id; set => id = value; }
        public int Age { get => age; set => age = value; }
    }
}
