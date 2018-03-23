using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main(string[] args)
    {
        List<Person> persons = new List<Person>();

        while (true)
        {
            string[] tokens = Console.ReadLine().Split();
            if (tokens[0] == "END") break;

            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            string town = tokens[2];

            Person person = new Person(name, age, town);

            persons.Add(person);
        }

        int position = int.Parse(Console.ReadLine());

        Person personToSearch = persons[position - 1];

        int counter = 0;
        foreach (var person in persons)
        {
            if (personToSearch.CompareTo(person) == 0) counter++;
        }

        if (counter == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{counter} {persons.Count - counter} {persons.Count}");
        }
    }
}