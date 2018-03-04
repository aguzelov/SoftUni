public abstract class Monument : IMonument
{
    private string name;
    private int affinity;
    private string type;

    protected Monument(string name, int affinity, string type)
    {
        Name = name;
        Affinity = affinity;
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

    public int Affinity
    {
        get
        {
            return this.affinity;
        }
        private set
        {
            this.affinity = value;
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

    public override string ToString()
    {
        return $"{Type} Monument: {Name}, {Type} Affinity: {Affinity}";
    }
}