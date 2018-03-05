using System;

public abstract class Provider : IProvider
{
    private string type;
    private string id;
    private double energyOutput;

    protected Provider(string id, double energyOutput)
    {
        this.type = this.GetType().Name.Replace("Provider", "");

        Id = id;
        EnergyOutput = energyOutput;
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

    public double EnergyOutput
    {
        get
        {
            return this.energyOutput;
        }
        protected set
        {
            if (value < 0)
            {
                throw new System.ArgumentOutOfRangeException(
                    nameof(EnergyOutput),
                    $"Value must be a positive"
                    );
            }

            if (value > 10000)
            {
                throw new System.ArgumentOutOfRangeException(
                    nameof(EnergyOutput),
                    $"Value must be less than 10000"
                    );
            }

            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        return $"{this.type} Provider - {Id}{Environment.NewLine}" +
                    $"Energy Output: {EnergyOutput}";
    }
}