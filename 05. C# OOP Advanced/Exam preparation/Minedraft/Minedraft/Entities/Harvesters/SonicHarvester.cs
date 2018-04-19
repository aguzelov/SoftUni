public class SonicHarvester : Harvester
{
    private const int EnergyRequirementDivider = 2;
    private const int DurabilityDecreaser = 300;

    public SonicHarvester(int id, double oreOutput, double energyRequirement)
        : base(id, oreOutput, energyRequirement /= EnergyRequirementDivider)
    {
        this.Durability -= DurabilityDecreaser;
    }
}