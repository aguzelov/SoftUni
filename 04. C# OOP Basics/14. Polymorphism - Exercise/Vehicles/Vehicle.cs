public abstract class Vehicle
{
    private string type;
    private double fuelQuantity;
    private double fuelConsumption;
    private double tankCapacity;
    private bool airConditioner;

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
            this.fuelQuantity = value;
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

    protected Vehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        Type = type;
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
        TankCapacity = tankCapacity;
    }

    public abstract void Drive(double distance);

    public abstract void Refuel(double fuel);
}