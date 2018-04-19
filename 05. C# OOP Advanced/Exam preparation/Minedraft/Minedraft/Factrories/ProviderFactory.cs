using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ProviderFactory : IProviderFactory
{
    private const string providerSuffix = "Provider";
    private const string errorMessage = "{0} is not IProvider type!";

    public IProvider GenerateProvider(IList<string> args)
    {
        string typeName = args[0];

        int id = int.Parse(args[1]);
        double energyOutput = double.Parse(args[2]);

        Type providerType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == typeName + providerSuffix);

        IProvider provider = (IProvider)Activator.CreateInstance(providerType, new object[]
        {
            id,
            energyOutput
        });

        return provider;
    }
}