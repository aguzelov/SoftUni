using System;

public abstract class Harvester : IHarvester
{
    private string type;
    private string id;
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.type = this.GetType().Name.Replace("Harvester", "");

        Id = id;
        OreOutput = oreOutput;
        EnergyRequirement = energyRequirement;
    }

    public string Id
    {
        get
        {
            return this.id;
        }
        private set
        {
            this.id = value;
        }
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
        return $"{this.type} Harvester - {Id}{Environment.NewLine}" +
                    $"Ore Output: {OreOutput}{Environment.NewLine}" +
                    $"Energy Requirement: {EnergyRequirement}";
    }
}