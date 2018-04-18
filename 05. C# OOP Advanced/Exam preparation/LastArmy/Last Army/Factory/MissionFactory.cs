using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        Type missionType = assembly.GetTypes().FirstOrDefault(t => t.Name == difficultyLevel);

        object[] ctorArgs = new object[] { neededPoints };

        IMission mission = (IMission)Activator.CreateInstance(missionType, ctorArgs);

        return mission;
    }
}