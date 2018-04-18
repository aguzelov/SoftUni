using System.Collections.Generic;

public class SpecialForce : Soldier
{
    private const double OverallSkillMiltiplier = 3.5;
    private const int SoldierRegenerateValue = 30;

    public SpecialForce(string name, int age, double experience, double endurance)
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
            "MachineGun",
            "RPG",
            "Helmet",
            "Knife",
            "NightVision"
        };

    public override void Regenerate()
    {
        this.Endurance += (SoldierRegenerateValue + this.Age);
    }
}