using System;

public abstract class Provider : IProvider
{
    private const int InitialDurability = 1000;
    private const int durabilityDecreaser = 100;

    private int id;
    private double durability;
    private double energyOutput;

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public int ID
    {
        get { return this.id; }
        private set { this.id = value; }
    }

    public double Durability
    {
        get { return this.durability; }
        protected set { this.durability = value; }
    }

    public double EnergyOutput
    {
        get { return this.energyOutput; }
        private set { this.energyOutput = value; }
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Broke()
    {
        this.Durability -= durabilityDecreaser;
        if (this.Durability < 0)
        {
            throw new Exception();
        }
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        return string.Format(Constants.EntityToString,
            this.GetType().Name,
            Environment.NewLine,
            this.Durability);
    }
}