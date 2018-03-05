using System;

public abstract class Harvester : Miner, IHarvester
{
    private string type;
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
        : base(id)
    {
        this.type = this.GetType().Name.Replace("Harvester", "");

        OreOutput = oreOutput;
        EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get
        {
            return this.oreOutput;
        }
        protected set
        {
            if (value < 0)
            {
                throw new System.ArgumentOutOfRangeException(
                    nameof(OreOutput),
                    $"Value must be a positive"
                    );
            }

            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get
        {
            return this.energyRequirement;
        }
        protected set
        {
            if (value < 0)
            {
                throw new System.ArgumentOutOfRangeException(
                    nameof(EnergyRequirement),
                    $"Value must be a positive"
                    );
            }

            if (value > 20000)
            {
                throw new System.ArgumentOutOfRangeException(
                    nameof(EnergyRequirement),
                    $"Value must be less than 20000"
                    );
            }

            this.energyRequirement = value;
        }
    }

    public override string ToString()
    {
        return $"{this.type} Harvester - {base.Id}{Environment.NewLine}" +
                    $"Ore Output: {OreOutput}{Environment.NewLine}" +
                    $"Energy Requirement: {EnergyRequirement}";
    }
}