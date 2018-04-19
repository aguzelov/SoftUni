public class SolarProvider : Provider
{
    private const int DurabilityIncrease = 500;

    public SolarProvider(int id, double energyOutput) : base(id, energyOutput)
    {
        this.Durability += DurabilityIncrease;
    }
}