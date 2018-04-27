using System.Collections.Generic;
using System.Text;

public class FireNation
{
    public List<FireBender> FireBenders { get; set; }
    public List<FireMonument> FireMonuments { get; set; }

    public FireNation()
    {
       this.FireBenders = new List<FireBender>();
        this.FireMonuments = new List<FireMonument>();
    }

    public void AddFireBender(FireBender fireBender)
    {
        this.FireBenders.Add(fireBender);
    }

    public void AddFireMonument(FireMonument fireMonument)
    {
        this.FireMonuments.Add(fireMonument);
    }

    public double GetTotalPower()
    {
        var powerOfNation = 0.0;
        foreach (var bender in FireBenders)
        {
            powerOfNation += bender.Power * bender.HeatAggression;
        }

        var monumentsPower = 0.0;

        foreach (var monument in FireMonuments)
        {
            monumentsPower += monument.FireAffinity;
        }

        var totalPower = (powerOfNation / 100) * monumentsPower;
        totalPower += powerOfNation;
        return totalPower;
    }

    public void DeleteNation()
    {
        this.FireBenders.Clear();
        this.FireMonuments.Clear();
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Fire Nation");           
        if (FireBenders.Count <= 0)
        {
            sb.AppendLine("Benders: None");
        }
        else
        {
            sb.AppendLine("Benders: ");
        }

        foreach (var air in FireBenders)
        {
            sb.AppendLine($"###Fire Bender: {air.Name}, Power: {air.Power}, Heat Aggression: {air.HeatAggression:f2}");
        }
        
        if (FireMonuments.Count <= 0)
        {
            sb.AppendLine("Monuments: None");
        }
        else
        {
            sb.AppendLine("Monuments: ");
            foreach (var air in FireMonuments)
            {
                sb.AppendLine($"###Fire Monument: {air.Name}, Fire Affinity: {air.FireAffinity}");
            }
        }

        return sb.ToString();
    }
}

