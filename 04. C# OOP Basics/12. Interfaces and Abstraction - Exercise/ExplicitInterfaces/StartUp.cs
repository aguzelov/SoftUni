using System;

public class StartUp
{
    public static void Main()
    {
        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split();
            string name = tokens[0];
            string country = tokens[1];
            int age = int.Parse(tokens[2]);

            Citizen citizen = new Citizen(name, country, age);

            IPerson ip = (IPerson)citizen;
            IResident ir = (IResident)citizen;

            Console.WriteLine(ip.GetName());
            Console.WriteLine(ir.GetName());
        }
    }
}