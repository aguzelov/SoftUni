using System;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        Type soldierType = assembly.GetTypes().FirstOrDefault(t => t.Name == soldierTypeName);

        object[] ctorArgs = new object[]{
               name,
               age,
               experience,
               endurance
            };

        ISoldier soldier = (ISoldier)Activator.CreateInstance(soldierType, ctorArgs);

        return soldier;
    }
}