using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<Soldier> soldiers = new List<Soldier>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split();
            string soldierType = tokens[0];
                
            Soldier soldier;
            try
            {
                soldier = SoldierFactory.GetSoldier(soldiers, soldierType, tokens);
            }
            catch (ArgumentException ex)
            {
                continue;
            }

            soldiers.Add(soldier);
        }

        Console.WriteLine(string.Join($"{Environment.NewLine}", soldiers));
    }
}