public interface IHarvester
{
    string Id { get; }
    double OreOutput { get; }
    double EnergyRequirement { get; }
}