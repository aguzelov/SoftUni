using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class HarvesterFactory : IHarvesterFactory
{
    private const string HarvesterSuffix = "Harvester";
    private const string errorMessage = "{0} is not IHarvester type!";

    public IHarvester GenerateHarvester(IList<string> args)
    {
        string typeName = args[0];

        var id = int.Parse(args[1]);
        var oreOutput = double.Parse(args[2]);
        var energyReq = double.Parse(args[3]);

        Type harvesterType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == typeName + HarvesterSuffix);

        IHarvester harvester = (IHarvester)Activator.CreateInstance(harvesterType, new object[]
        {
            id,
            oreOutput,
            energyReq
        });

        return harvester;
    }
}