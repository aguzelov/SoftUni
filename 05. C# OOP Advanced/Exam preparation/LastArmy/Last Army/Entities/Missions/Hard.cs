public class Hard : Mission
{
    private const string MissionName = "Disposal of terrorists";
    private const double MissionEndurance = 80;
    private const double MissionWearLevel = 70;

    public Hard(double scoreToComplete)
        : base(scoreToComplete)
    {
    }

    public override double EnduranceRequired => MissionEndurance;

    public override double WearLevelDecrement => MissionWearLevel;

    public override string Name => MissionName;
}