internal class Car : Vehicle
{
    private const double summerIncreasedConsumption = 0.9;

    public Car(string type, double fuelQuantity, double fuelConsumption)
        : base(type, fuelQuantity, fuelConsumption)
    {
    }

    public override void Drive(double distance)
    {
        double needFuel = distance * (base.FuelConsumption + summerIncreasedConsumption);

        if (needFuel <= base.FuelQuantity)
        {
            Writer.WriteLine($"{Type} travelled {distance} km");
            base.FuelQuantity -= needFuel;
        }
        else
        {
            Writer.WriteLine($"{Type} needs refueling");
        }
    }

    public override void Refuel(double fuel)
    {
        base.FuelQuantity += fuel;
    }

    public override string ToString()
    {
        return $"{Type}: {base.FuelQuantity:F2}";
    }
}