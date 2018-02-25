using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Rebellion> rebellions = new List<Rebellion>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split();
            if (tokens[0] == "Citizen")
            {
                string name = tokens[1];
                int age = int.Parse(tokens[2]);
                string id = tokens[3];
                string birthdate = tokens[4];
                rebellions.Add(new Citizen(name, age, id, birthdate));
            }
            else if (tokens[0] == "Pet")
            {
                string name = tokens[1];
                string birthdate = tokens[2];
                rebellions.Add(new Pet(name, birthdate));
            }
        }

        string year = Console.ReadLine();

        rebellions.Where(r => r.Birthdate.EndsWith(year)).ToList().ForEach(r => Console.WriteLine(r));
    }
}