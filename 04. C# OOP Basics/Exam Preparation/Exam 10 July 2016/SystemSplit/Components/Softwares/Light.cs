public class Light : Software
{
    public Light(string name, int capacityConsumption, int memoryConsumption) : base(name, capacityConsumption, memoryConsumption)
    {
        IncreaseCapacityConsumption();
        DecreaseMemoryConsumption();
    }

    private void IncreaseCapacityConsumption()
    {
        base.CapacityConsumption += (base.CapacityConsumption / 2);
    }

    private void DecreaseMemoryConsumption()
    {
        base.MemoryConsumption -= (base.MemoryConsumption / 2);
    }
}