using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const double AmountOfEndurance = 100;
    private const double RegenerateValue = 10;
    private string name;
    private int age;
    private double endurance;
    private double experience;

    public Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;      
        this.Experience = experience;
        this.Endurance = endurance;
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
            if (value > 100)
            {
                value = 100;
            }

            this.endurance = value;
        }
    }
    public abstract double OverallSkill { get; }

    public IDictionary<string, IAmmunition> Weapons { get; protected set; }

    public abstract void Regenerate();

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        if (this.Weapons.Any(a => a.Value == null || a.Value.WearLevel <= 0))
        {
            return false;
        }

        if (this.Weapons.Any(a => a.Value.WearLevel < 1))
        {
            return false;
        }

        return true;
    }

    public void CompleteMission(IMission mission)
    {
        this.Experience += mission.EnduranceRequired;
        this.Endurance -= mission.EnduranceRequired;
        this.AmmunitionRevision(mission.WearLevelDecrement);
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

    public override string ToString() => string.Format(OutputMessages.SoldierToString,
                                                        this.Name, this.OverallSkill);
}