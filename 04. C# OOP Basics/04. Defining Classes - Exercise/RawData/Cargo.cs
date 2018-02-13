public class Cargo
{
    public int CargoWeight { get; set; }
    public string CargoType { get; set; }

    public Cargo(int cargoWeight, string cargoType)
    {
        CargoWeight = cargoWeight;
        CargoType = cargoType;
    }
}