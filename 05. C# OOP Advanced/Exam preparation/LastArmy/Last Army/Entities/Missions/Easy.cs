public class Easy : Mission
{
    private const string MissionName = "Suppression of civil rebellion";
    private const double MissionEndurance = 20;
    private const double MissionWearLevel = 30;

    public Easy(double scoreToComplete)
        : base(scoreToComplete)
    {
    }

    public override double EnduranceRequired => MissionEndurance;

    public override double WearLevelDecrement => MissionWearLevel;

    public override string Name => MissionName;
}