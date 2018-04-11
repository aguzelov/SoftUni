using System;
using System.Collections.Generic;
using System.Linq;

namespace KingsGambit
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string kingName = Console.ReadLine();
            King king = new King(kingName);

            List<Soldier> soldiers = new List<Soldier>();
            GetSoldiers(king, "Royal");
            GetSoldiers(king, "Footman");

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commandArgs = input.Split();
                string command = commandArgs[0];

                switch (command)
                {
                    case "Attack":
                        king.OnAttack();
                        break;

                    case "Kill":
                        string soldierName = commandArgs[1];
                        var soldier = king.Soldiers.FirstOrDefault(s => s.Name == soldierName);
                        soldier.TakeAttack();
                        break;
                }
            }
        }

        private static void GetSoldiers(King king, string soldierType)
        {
            string[] soldiersNames = Console.ReadLine().Split();

            foreach (var name in soldiersNames)
            {
                Soldier soldier = null;
                switch (soldierType)
                {
                    case "Royal":
                        soldier = new RoyalGuard(name);
                        break;

                    case "Footman":
                        soldier = new Footman(name);
                        break;
                }

                king.AddSoldier(soldier);
            }
        }
    }
}