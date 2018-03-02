internal class Car : Vehicle
{
    private const double summerIncreasedConsumption = 0.9;

    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base("Car", fuelQuantity, fuelConsumption, tankCapacity)
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
}