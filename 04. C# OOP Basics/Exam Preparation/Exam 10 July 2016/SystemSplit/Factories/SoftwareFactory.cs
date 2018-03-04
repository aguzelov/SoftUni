public static class SoftwareFactory
{
    public static Software CreateSoftware(string type, string[] softwareArgs)
    {
        string name = softwareArgs[0];
        int capacity = int.Parse(softwareArgs[1]);
        int memory = int.Parse(softwareArgs[2]);

        switch (type)
        {
            case "Express":
                return new Express(name, capacity, memory);

            case "Light":
                return new Light(name, capacity, memory);

            default:
                throw new System.ArgumentOutOfRangeException(nameof(type), "Software type must be Express or Light");
        }
    }
}