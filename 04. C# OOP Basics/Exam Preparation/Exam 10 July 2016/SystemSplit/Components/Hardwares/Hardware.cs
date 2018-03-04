using System.Collections.Generic;
using System.Linq;

public abstract class Hardware : IHardware
{
    private string name;
    private int maximumCapacity;
    private int maximumMemory;
    private List<Software> softwares;

    protected Hardware(string name, int maximumCapacity, int maximumMemory)
    {
        Name = name;
        MaximumCapacity = maximumCapacity;
        MaximumMemory = maximumMemory;
        this.softwares = new List<Software>();
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

    public int MaximumCapacity
    {
        get
        {
            return this.maximumCapacity;
        }
        protected set
        {
            this.maximumCapacity = value;
        }
    }

    public int MaximumMemory
    {
        get
        {
            return this.maximumMemory;
        }
        protected set
        {
            this.maximumMemory = value;
        }
    }

    public int TotalOperationalMemoryInUse
    {
        get
        {
            return softwares.Sum(s => s.MemoryConsumption);
        }
    }

    public int TotalCapacityTaken
    {
        get
        {
            return softwares.Sum(s => s.CapacityConsumption);
        }
    }

    public List<Software> Softwares
    {
        get
        {
            return this.softwares;
        }
    }

    public void AddSoftwareComponent(Software software)
    {
        int currentSoftwareCapacity = software.CapacityConsumption;
        int currentSoftwareMemory = software.MemoryConsumption;

        if (MaximumCapacity - (TotalCapacityTaken + currentSoftwareCapacity) < 0 ||
            MaximumMemory - (TotalOperationalMemoryInUse + currentSoftwareMemory) < 0)
        {
            throw new System.ArgumentOutOfRangeException();
        }

        this.softwares.Add(software);
    }

    public Software ReleaseSoftwareComponent(string softwareComponentName)
    {
        if (!softwares.Exists(s => s.Name == softwareComponentName))
        {
            throw new System.ArgumentOutOfRangeException();
        }

        Software software = softwares.FirstOrDefault(s => s.Name == softwareComponentName);
        softwares.Remove(software);

        return software;
    }
}