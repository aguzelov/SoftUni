internal class Bus : Vehicle
{
    private const double summerIncreasedConsumption = 1.4;

    public Bus(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(type, fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    public override void Drive(double distance)
    {
        if (base.AirConditioner)
        {
            Drive(distance, base.FuelConsumption + summerIncreasedConsumption);
        }
        else
        {
            Drive(distance, base.FuelConsumption);
        }
    }

    private void Drive(double distance, double consumpion)
    {
        double needFuel = distance * consumpion;

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
        if (base.FuelQuantity + fuel < 0)
        {
            Writer.WriteLine("Fuel must be a positive number");
            return;
        }
        else if (base.FuelQuantity + fuel > base.TankCapacity)
        {
            Writer.WriteLine("Cannot fit fuel in tank");
        }
        else
        {
            base.FuelQuantity += fuel;
        }
    }

    public override string ToString()
    {
        return $"{Type}: {base.FuelQuantity:F2}";
    }
}