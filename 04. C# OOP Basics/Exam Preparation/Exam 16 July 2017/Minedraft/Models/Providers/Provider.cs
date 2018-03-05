using System;

public abstract class Provider : Miner, IProvider
{
    private string type;

    private double energyOutput;

    protected Provider(string id, double energyOutput)
        : base(id)
    {
        this.type = this.GetType().Name.Replace("Provider", "");

        EnergyOutput = energyOutput;
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
        return $"{this.type} Provider - {base.Id}{Environment.NewLine}" +
                    $"Energy Output: {EnergyOutput}";
    }
}