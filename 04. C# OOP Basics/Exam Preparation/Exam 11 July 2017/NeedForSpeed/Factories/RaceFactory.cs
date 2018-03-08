public static class RaceFactory
{
    public static Race Create(string type, int length, string route, int prizePool, string extra = null)
    {
        switch (type)
        {
            case "Casual":
                return new CasualRace(length, route, prizePool);

            case "Drag":
                return new DragRace(length, route, prizePool);

            case "Drift":
                return new DriftRace(length, route, prizePool);

            case "TimeLimit":
                int goldTime = int.Parse(extra);
                return new TimeLimitRace(length, route, prizePool, goldTime);

            case "Circuit":
                int laps = int.Parse(extra);
                return new CircuitRace(length, route, prizePool, laps);

            default:
                throw new System.ArgumentOutOfRangeException(
                    nameof(type),
                    $"Race type must be “Casual”, “Drag”, “Drift”, “TimeLimit” or “Circuit”!");
        }
    }
}