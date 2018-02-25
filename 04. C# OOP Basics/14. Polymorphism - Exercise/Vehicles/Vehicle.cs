public abstract class Vehicle
{
    private string type;
    private double fuelQuantity;
    private double fuelConsumption;

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

    protected Vehicle(string type, double fuelQuantity, double fuelConsumption)
    {
        Type = type;
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
    }

    public abstract void Drive(double distance);

    public abstract void Refuel(double fuel);
}