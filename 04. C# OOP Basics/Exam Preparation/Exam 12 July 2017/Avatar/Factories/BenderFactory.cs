using System.Collections.Generic;

public static class BenderFactory
{
    public static Bender CreateBender(List<string> benderArgs)
    {
        string type = benderArgs[0];
        string name = benderArgs[1];
        int power = int.Parse(benderArgs[2]);
        double secondaryParameter = double.Parse(benderArgs[3]);

        switch (type)
        {
            case "Air":
                return new AirBender(name, power, secondaryParameter);

            case "Water":
                return new WaterBender(name, power, secondaryParameter);

            case "Fire":
                return new FireBender(name, power, secondaryParameter);

            case "Earth":
                return new EarthBender(name, power, secondaryParameter);

            default:
                throw new System.ArgumentOutOfRangeException(nameof(type), "Bender`s type must be Air, Water, Fire or Earth!");
        }
    }
}