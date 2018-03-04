public abstract class Bender : IBender
{
    private string name;
    private int power;
    private double secondaryParameter;
    private string type;

    protected Bender(string name, int power, double secondaryParameter, string type)
    {
        Name = name;
        Power = power;
        SecondaryParameter = secondaryParameter;
        Type = type;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            this.name = value;
        }
    }

    public int Power
    {
        get
        {
            return this.power;
        }
        private set
        {
            this.power = value;
        }
    }

    public double SecondaryParameter
    {
        get
        {
            return this.secondaryParameter;
        }
        private set
        {
            this.secondaryParameter = value;
        }
    }

    public string Type
    {
        get
        {
            return this.type;
        }
        private set
        {
            this.type = value;
        }
    }

    public double TotalPower
    {
        get
        {
            return this.power * this.secondaryParameter;
        }
    }

    protected string ToString(string secondaryParameterName)
    {
        return $"{Type} Bender: {Name}, Power: {Power}, {secondaryParameterName}: {SecondaryParameter:F2}";
    }
}