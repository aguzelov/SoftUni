public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput)
        : base(id, energyOutput)
    {
        base.EnergyOutput = base.EnergyOutput + ((base.EnergyOutput / 100) * 50);
    }
}