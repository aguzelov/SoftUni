internal class Bus : Vehicle
{
    private const double summerIncreasedConsumption = 1.4;

    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base("Bus", fuelQuantity, fuelConsumption, tankCapacity)
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
}