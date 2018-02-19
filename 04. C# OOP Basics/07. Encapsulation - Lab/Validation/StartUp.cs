using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main(string[] args)
    {

        var lines = int.Parse(Console.ReadLine());
        var persons = new List<Person>();
        for (int i = 0; i < lines; i++)
        {
            var cmdArgs = Console.ReadLine().Split();
            Person person = null;
            try
            {
                person = new Person(cmdArgs[0],
                                   cmdArgs[1],
                                   int.Parse(cmdArgs[2]),
                                   decimal.Parse(cmdArgs[3]));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }
           
            persons.Add(person);
        }
        var bonus = decimal.Parse(Console.ReadLine());
        persons.ForEach(p => p.IncreaseSalary(bonus));
        persons.ForEach(p => Console.WriteLine(p.ToString()));

    }
}