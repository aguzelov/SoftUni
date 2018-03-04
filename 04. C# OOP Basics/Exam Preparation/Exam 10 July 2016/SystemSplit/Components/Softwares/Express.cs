public class Express : Software
{
    public Express(string name, int capacityConsumption, int memoryConsumption) : base(name, capacityConsumption, memoryConsumption)
    {
        IncreaseMemoryConsumption();
    }

    private void IncreaseMemoryConsumption()
    {
        base.MemoryConsumption *= 2;
    }
}