public class Medium : Mission
{
    private const string MissionName = "Capturing dangerous criminals";
    private const double MissionEndurance = 50;
    private const double MissionWearLevel = 50;

    public Medium(double scoreToComplete)
        : base(scoreToComplete)
    {
    }

    public override double EnduranceRequired => MissionEndurance;

    public override double WearLevelDecrement => MissionWearLevel;

    public override string Name => MissionName;
}