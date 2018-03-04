public static class HardwareFactory
{
    public static Hardware CreateHardware(string type, string[] hardwareArgs)
    {
        string name = hardwareArgs[0];
        int capacity = int.Parse(hardwareArgs[1]);
        int memory = int.Parse(hardwareArgs[2]);
        switch (type)
        {
            case "Power":
                return new Power(name, capacity, memory);

            case "Heavy":
                return new Heavy(name, capacity, memory);

            default:
                throw new System.ArgumentOutOfRangeException(nameof(type), "Hardware type must be a Power or Heavy");
        }
    }
}