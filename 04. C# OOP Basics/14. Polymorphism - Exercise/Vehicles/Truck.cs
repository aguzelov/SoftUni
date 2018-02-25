internal class Truck : Vehicle
{
    private const double summerIncreasedConsumption = 1.6;

    public Truck(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(type, fuelQuantity, fuelConsumption, tankCapacity)
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
        if (fuel < 0)
        {
            Writer.WriteLine("Fuel must be a positive number");
            return;
        }

        base.FuelQuantity += (fuel * 0.95);
    }

    public override string ToString()
    {
        return $"{Type}: {base.FuelQuantity:F2}";
    }
}