using System.Collections.Generic;

public static class ProviderFactory
{
    public static Provider Create(List<string> providerArgs)
    {
        string type = providerArgs[0];
        string id = providerArgs[1];
        double energyOutput = double.Parse(providerArgs[2]);

        switch (type)
        {
            case "Solar":
                return new SolarProvider(id, energyOutput);

            case "Pressure":
                return new PressureProvider(id, energyOutput);

            default:
                throw new System.ArgumentOutOfRangeException(
                    nameof(type),
                    $"Provider type must be Pressure or Solar!");
        }
    }
}