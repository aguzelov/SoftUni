using System.Collections.Generic;

public class Ranker : Soldier
{
    private const double OverallSkillMiltiplier = 1.5;

    public Ranker(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    public override double OverallSkill
    {
        get
        {
            return (this.Age + this.Experience) * OverallSkillMiltiplier;
        }
    }

    protected override IReadOnlyList<string> WeaponsAllowed => new List<string>()
    {
        "Gun",
        "AutomaticMachine",
        "Helmet"
    };
}