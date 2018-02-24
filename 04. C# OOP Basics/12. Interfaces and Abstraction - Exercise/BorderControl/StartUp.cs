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
            if (tokens.Length == 3)
            {
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string id = tokens[2];
                rebellions.Add(new Citizen(name, age, id));
            }
            else
            {
                string model = tokens[0];
                string id = tokens[1];
                rebellions.Add(new Robot(model, id));
            }
        }

        string fakeIdsLastDigits = Console.ReadLine();

        rebellions.Where(r => r.Id.EndsWith(fakeIdsLastDigits)).ToList().ForEach(r => Console.WriteLine(r));
    }
}