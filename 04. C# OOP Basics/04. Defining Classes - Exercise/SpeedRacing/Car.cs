using System;

class Car
{

    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumption { get; set; }
    public double DistanceTraveled { get; set; }

    public Car(string model, double fuelAmount, double fuelConsumption)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelConsumption = fuelConsumption;
        DistanceTraveled = 0;
    }

    public void Move(double amountOfKm)
    {
        double neededFuel = amountOfKm * FuelConsumption;
        if (neededFuel <= FuelAmount)
        {
            FuelAmount -= neededFuel;
            DistanceTraveled += amountOfKm;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }

    public override string ToString()
    {
        return $"{Model} {FuelAmount:F2} {DistanceTraveled}";
    }
}
