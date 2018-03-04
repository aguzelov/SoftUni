public abstract class Software : ISoftware
{
    private string name;
    private int capacityConsumption;
    private int memoryConsumption;

    protected Software(string name, int capacityConsumption, int memoryConsumption)
    {
        Name = name;
        CapacityConsumption = capacityConsumption;
        MemoryConsumption = memoryConsumption;
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

    public int CapacityConsumption
    {
        get
        {
            return this.capacityConsumption;
        }
        protected set
        {
            this.capacityConsumption = value;
        }
    }

    public int MemoryConsumption
    {
        get
        {
            return this.memoryConsumption;
        }
        protected set
        {
            this.memoryConsumption = value;
        }
    }

    public override string ToString()
    {
        return $"{Name}";
    }
}