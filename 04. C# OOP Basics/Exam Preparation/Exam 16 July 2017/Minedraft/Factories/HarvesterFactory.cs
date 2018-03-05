using System.Collections.Generic;

public static class HarvesterFactory
{
    public static Harvester Create(List<string> harvesterArgs)
    {
        string type = harvesterArgs[0];
        string id = harvesterArgs[1];
        double oreOutput = double.Parse(harvesterArgs[2]);
        double energyRequirement = double.Parse(harvesterArgs[3]);

        switch (type)
        {
            case "Hammer":
                return new HammerHarvester(id, oreOutput, energyRequirement);

            case "Sonic":
                int sonicFactor = int.Parse(harvesterArgs[4]);
                return new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);

            default:
                throw new System.ArgumentOutOfRangeException(
                    nameof(type),
                    "Harvester type must be Hammer or Sonic!");
        }
    }
}