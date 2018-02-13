using System.Transactions;

public class Tire
{
    public double TirePressure { get; set; }
    public int TireAge { get; set; }

    public Tire(double tirePressure, int tireAge)
    {
        TirePressure = tirePressure;
        TireAge = tireAge;
    }
}