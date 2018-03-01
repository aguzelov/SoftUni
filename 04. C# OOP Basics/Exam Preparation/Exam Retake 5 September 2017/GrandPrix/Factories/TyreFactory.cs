using System.Collections.Generic;

public static class TyreFactory
{
    public static Tyre Create(List<string> tyreArgs)
    {
        string type = tyreArgs[0];
        double hardness = double.Parse(tyreArgs[1]);

        switch (type)
        {
            case "Ultrasoft":
                double grip = double.Parse(tyreArgs[2]);
                return new UltrasoftTyre(hardness, grip);

            case "Hard":
                return new HardTyre(hardness);

            default:
                throw new System.ArgumentException();
        }
    }
}