using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Person> persons = new List<Person>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] personalInformation = Console.ReadLine().Split();

            string name = personalInformation[0];
            int age = int.Parse(personalInformation[1]);

            persons.Add(new Person(name, age));
        }

        foreach (var person in persons.Where(a=> a.age > 30).OrderBy(a => a.name))
        {
            Console.WriteLine($"{person.name} - {person.age}");
        }
    }
}
