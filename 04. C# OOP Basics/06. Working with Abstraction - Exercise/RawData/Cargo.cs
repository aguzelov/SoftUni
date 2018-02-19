class Cargo
{
    private int cargoWeight;

    public int CargoWeight
    {
        get { return this.cargoWeight; }
        set { this.cargoWeight = value; }
    }

    private string cargoType;

    public string CargoType
    {
        get { return this.cargoType; }
        set { this.cargoType = value; }
    }

    public Cargo(int cargoWeight, string cargoType)
    {
        this.cargoWeight = cargoWeight;
        this.cargoType = cargoType;
    }

    public Cargo()
    {
    }
}