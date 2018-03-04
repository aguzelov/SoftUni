public class Heavy : Hardware
{
    public Heavy(string name, int maximumCapacity, int maximumMemory) : base(name, maximumCapacity, maximumMemory)
    {
        IncreaseCapacity();
        DecreaseMemory();
    }

    private void IncreaseCapacity()
    {
        base.MaximumCapacity = base.MaximumCapacity * 2;
    }

    private void DecreaseMemory()
    {
        base.MaximumMemory = base.MaximumMemory - (base.MaximumMemory / 4);
    }
}