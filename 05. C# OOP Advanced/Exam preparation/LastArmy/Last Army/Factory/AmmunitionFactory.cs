using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        Type ammunitionType = assembly.GetTypes().Where(t => t.Name == ammunitionName).First();

        object[] ctorArgs = new object[] { ammunitionName };

        IAmmunition ammunition = (IAmmunition)Activator.CreateInstance(ammunitionType, ctorArgs);

        return ammunition;
    }
}