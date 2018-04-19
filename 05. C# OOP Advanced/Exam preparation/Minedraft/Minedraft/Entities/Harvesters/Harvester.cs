using System;

public abstract class Harvester : IHarvester
{
    private const int InitialDurability = 1000;
    private const int durabilityDecreaser = 100;
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.ID = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double OreOutput
    {
        get { return this.oreOutput; }
        private set { this.oreOutput = value; }
    }

    public double EnergyRequirement
    {
        get { return this.energyRequirement; }
        private set { this.energyRequirement = value; }
    }

    public virtual double Durability { get; protected set; }

    public double Produce()
    {
        return this.OreOutput;
    }

    public virtual void Broke()
    {
        this.Durability -= durabilityDecreaser;
        if (this.Durability < 0)
        {
            throw new Exception();
        }
    }

    public override string ToString()
    {
        return string.Format(Constants.EntityToString,
            this.GetType().Name,
            Environment.NewLine,
            this.Durability);
    }
}