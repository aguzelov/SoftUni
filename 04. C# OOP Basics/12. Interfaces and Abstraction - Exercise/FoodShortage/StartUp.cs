using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Person> persons = new List<Person>();

        int numberOfPeople = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfPeople; i++)
        {
            string[] tokens = Console.ReadLine().Split();
            if (tokens.Length == 4)
            {
                string citizenName = tokens[0];
                int age = int.Parse(tokens[1]);
                string id = tokens[2];
                string birthdate = tokens[3];

                persons.Add(new Citizen(citizenName, age, id, birthdate));
            }
            else if (tokens.Length == 3)
            {
                string rebelName = tokens[0];
                int age = int.Parse(tokens[1]);
                string group = tokens[2];

                persons.Add(new Rebel(rebelName, age, group));
            }
        }

        string name = string.Empty;
        while ((name = Console.ReadLine()) != "End")
        {
            if (persons.Any(p => p.Name == name))
            {
                Person person = persons.FirstOrDefault(p => p.Name == name);
                person.BuyFood();
            }
        }

        Console.WriteLine(Person.TotalFood);
    }
}