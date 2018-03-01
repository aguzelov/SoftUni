using System.Collections.Generic;

public static class CarFactory
{
    public static Car Create(List<string> carArgs, Tyre tyre)
    {
        int hp = int.Parse(carArgs[0]);
        double fuelAmount = double.Parse(carArgs[1]);

        return new Car(hp, fuelAmount, tyre);
    }
}