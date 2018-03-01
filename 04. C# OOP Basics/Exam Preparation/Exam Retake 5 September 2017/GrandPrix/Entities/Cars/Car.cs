using System;

public class Car
{
    private const int MaximumFuelTankCapacity = 160;

    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; }

    public double FuelAmount
    {
        get => this.fuelAmount;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }
            this.fuelAmount = value > MaximumFuelTankCapacity ? MaximumFuelTankCapacity : value;
        }
    }

    public Tyre Tyre
    {
        get => this.tyre;
        private set => this.tyre = value;
    }

    public void ReduceFuel(int length, double fuelConsumption)
    {
        this.FuelAmount = this.FuelAmount - (length * fuelConsumption);
    }

    public void Refuel(double fuel)
    {
        this.FuelAmount += fuel;
    }

    public void ChangeTyre(Tyre newTyre)
    {
        this.Tyre = newTyre;
    }
}