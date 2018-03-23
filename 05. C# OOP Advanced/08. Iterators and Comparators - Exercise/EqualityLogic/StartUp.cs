using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main(string[] args)
    {
        int numberOfPerson = int.Parse(Console.ReadLine());

        SortedSet<Person> sortedSet = new SortedSet<Person>();
        HashSet<Person> hashSet = new HashSet<Person>();

        while (--numberOfPerson >= 0)
        {
            string[] tokens = Console.ReadLine().Split();
            string name = tokens[0];
            int age = int.Parse(tokens[1]);

            Person person = new Person(name, age);

            sortedSet.Add(person);
            hashSet.Add(person);
        }

        Console.WriteLine(sortedSet.Count);
        Console.WriteLine(hashSet.Count);
    }
}