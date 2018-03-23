using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main(string[] args)
    {
        int numberOfPerson = int.Parse(Console.ReadLine());

        SortedSet<Person> nameSortedSet = new SortedSet<Person>(new NameComparator());
        SortedSet<Person> ageSortedSet = new SortedSet<Person>(new AgeComparator());

        while (--numberOfPerson >= 0)
        {
            string[] tokens = Console.ReadLine().Split();
            string name = tokens[0];
            int age = int.Parse(tokens[1]);

            Person person = new Person(name, age);

            nameSortedSet.Add(person);
            ageSortedSet.Add(person);
        }

        Console.WriteLine(string.Join($"{Environment.NewLine}", nameSortedSet));
        Console.WriteLine(string.Join($"{Environment.NewLine}", ageSortedSet));
    }
}