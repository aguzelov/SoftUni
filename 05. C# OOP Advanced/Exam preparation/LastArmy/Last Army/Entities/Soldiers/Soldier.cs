using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const int MaxEndurance = 100;
    private const int SoldierRegenerateValue = 10;

    private double endurance;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        Name = name;
        Age = age;
        Experience = experience;
        Endurance = endurance;

        this.Weapons = new Dictionary<string, IAmmunition>();

        SetWeapons();
    }

    private void SetWeapons()
    {
        foreach (var weaponName in WeaponsAllowed)
        {
            Weapons.Add(weaponName, null);
        }
    }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public double Experience { get; private set; }

    public double Endurance
    {
        get
        {
            return this.endurance;
        }
        protected set
        {
            this.endurance = Math.Min(MaxEndurance, value);
        }
    }

    public abstract double OverallSkill { get; }

    public IDictionary<string, IAmmunition> Weapons { get; }

    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public virtual void Regenerate()
    {
        this.Endurance += (SoldierRegenerateValue + this.Age);
    }

    public void CompleteMission(IMission mission)
    {
        this.Experience += mission.EnduranceRequired;
        this.Endurance -= mission.EnduranceRequired;

        this.AmmunitionRevision(mission.WearLevelDecrement);
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
}