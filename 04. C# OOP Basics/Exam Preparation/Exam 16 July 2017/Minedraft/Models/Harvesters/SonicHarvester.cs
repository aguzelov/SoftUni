public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
        : base(id, oreOutput, energyRequirement)
    {
        base.EnergyRequirement = base.EnergyRequirement / sonicFactor;
        SonicFactor = sonicFactor;
    }

    public int SonicFactor
    {
        get
        {
            return this.sonicFactor;
        }
        private set
        {
            this.sonicFactor = value;
        }
    }
}