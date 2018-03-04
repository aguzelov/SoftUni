using System.Collections.Generic;

public static class MonumentFactory
{
    public static Monument CreateMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[0];
        string name = monumentArgs[1];
        int affinity = int.Parse(monumentArgs[2]);

        switch (type)
        {
            case "Air":
                return new AirMonument(name, affinity);

            case "Water":
                return new WaterMonument(name, affinity);

            case "Fire":
                return new FireMonument(name, affinity);

            case "Earth":
                return new EarthMonument(name, affinity);

            default:
                throw new System.ArgumentOutOfRangeException(nameof(type), "Monument`s type must be Air, Water, Fire or Earth!");
        }
    }
}