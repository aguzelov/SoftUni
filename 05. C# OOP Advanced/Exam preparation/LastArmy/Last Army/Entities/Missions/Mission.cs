public abstract class Mission : IMission
{
    protected Mission(double scoreToComplete)
    {
        ScoreToComplete = scoreToComplete;
    }

    public double ScoreToComplete { get; }

    public abstract double EnduranceRequired { get; }

    public abstract double WearLevelDecrement { get; }

    public abstract string Name { get; }
}