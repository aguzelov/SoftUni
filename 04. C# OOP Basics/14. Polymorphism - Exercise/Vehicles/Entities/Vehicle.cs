public abstract class Vehicle
{
    private string type;
    private double fuelQuantity;
    private double fuelConsumption;
    private double tankCapacity;
    private bool airConditioner;

    protected Vehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        Type = type;
        TankCapacity = tankCapacity;
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
    }

    public string Type
    {
        get
        {
            return this.type;
        }
        private set
        {
            this.type = value;
        }
    }

    public double FuelQuantity
    {
        get
        {
            return this.fuelQuantity;
        }
        set
        {
            if (value > TankCapacity)
            {
                this.fuelQuantity = 0;
            }
            else
            {
                this.fuelQuantity = value;
            }

        }
    }

    public double FuelConsumption
    {
        get
        {
            return this.fuelConsumption;
        }
        set
        {
            this.fuelConsumption = value;
        }
    }

    public double TankCapacity
    {
        get
        {
            return this.tankCapacity;
        }
        private set
        {
            this.tankCapacity = value;
        }
    }

    public bool AirConditioner
    {
        get
        {
            return this.airConditioner;
        }
        set
        {
            this.airConditioner = value;
        }
    }
    
    public abstract void Drive(double distance);

    public virtual void Refuel(double fuel)
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
            FuelQuantity += fuel;
        }
    }

    public override string ToString()
    {
        return $"{Type}: {FuelQuantity:F2}";
    }
}