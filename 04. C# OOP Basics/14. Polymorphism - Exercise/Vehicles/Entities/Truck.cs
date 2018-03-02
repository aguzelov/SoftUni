internal class Truck : Vehicle
{
    private const double summerIncreasedConsumption = 1.6;

    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base("Truck", fuelQuantity, fuelConsumption, tankCapacity)
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
        if (fuel <= 0)
        {
            Writer.WriteLine("Fuel must be a positive number");
        }
        else if (FuelQuantity + fuel > TankCapacity)
        {
            Writer.WriteLine($"Cannot fit {fuel} fuel in the tank");
        }
        else
        {
            FuelQuantity += (fuel*0.95);
        }
    }
}