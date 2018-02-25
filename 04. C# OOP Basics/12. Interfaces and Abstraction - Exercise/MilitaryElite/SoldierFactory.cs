using System;
using System.Collections.Generic;
using System.Linq;

public static class SoldierFactory
{
    public static Soldier GetSoldier(List<Soldier> soldiers, string soldierType, string[] data)
    {
        int id = int.Parse(data[1]);
        string firstName = data[2];
        string lastName = data[3];

        switch (soldierType)
        {
            case "Private":
                decimal privateSalary = decimal.Parse(data[4]);

                return new Private(id, firstName, lastName, privateSalary);

            case "LeutenantGeneral":
                decimal leutenantSalary = decimal.Parse(data[4]);
                LeutenantGeneral leutenant = new LeutenantGeneral(id, firstName, lastName, leutenantSalary);
                for (int i = 5; i < data.Length; i++)
                {
                    int privateId = int.Parse(data[i]);
                    Private currentPrivate = (Private)soldiers.FirstOrDefault(p => p.Id == privateId);

                    leutenant.AddPrivate(currentPrivate);
                }

                return leutenant;

            case "Engineer":
                decimal engineerSalary = decimal.Parse(data[4]);
                string enginnerCopr = data[5];
                Engineer engineer = new Engineer(id, firstName, lastName, engineerSalary, enginnerCopr);
                for (int i = 6; i < data.Length; i += 2)
                {
                    string part = data[i];
                    int hours = int.Parse(data[i + 1]);
                    Repair repair = new Repair(part, hours);

                    engineer.AddRepair(repair);
                }

                return engineer;

            case "Commando":
                decimal commandoSalary = decimal.Parse(data[4]);
                string commandoCopr = data[5];
                Commando commando = new Commando(id, firstName, lastName, commandoSalary, commandoCopr);

                for (int i = 6; i < data.Length; i += 2)
                {
                    string codeName = data[i];
                    string state = data[i + 1];
                    Mission mission;
                    try
                    {
                        mission = new Mission(codeName, state);
                    }
                    catch (ArgumentException ex)
                    {
                        continue;
                    }

                    commando.AddMission(mission);
                }

                return commando;

            case "Spy":
                int codeNumber = int.Parse(data[4]);
                return new Spy(id, firstName, lastName, codeNumber);

            default:
                throw new ArgumentException();
        }
    }
}