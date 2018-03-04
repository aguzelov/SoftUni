public class Power : Hardware
{
    public Power(string name, int maximumCapacity, int maximumMemory) : base(name, maximumCapacity, maximumMemory)
    {
        DecreaseCapacity();
        IncreaseMemory();
    }

    private void DecreaseCapacity()
    {
        base.MaximumCapacity = base.MaximumCapacity - ((base.MaximumCapacity * 3) / 4);
    }

    private void IncreaseMemory()
    {
        base.MaximumMemory = base.MaximumMemory + ((base.MaximumMemory * 3) / 4);
    }
}