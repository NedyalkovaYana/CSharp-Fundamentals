using System.Collections.Generic;
using System.Text;

public  class EarthNation
{
    public List<EarthBender> EarthBenders { get; set; }
    public List<EarthMonument> EarthMonuments { get; set; }

    public EarthNation()
    {
        this.EarthBenders = new List<EarthBender>();
        this.EarthMonuments = new List<EarthMonument>();
    }

    public void AddEarthBender(EarthBender earthBender)
    {
        this.EarthBenders.Add(earthBender);
    }

    public void AddEartMonument(EarthMonument earthMonument)
    {
        this.EarthMonuments.Add(earthMonument);
    }

    public double GetTotalPower()
    {
        var powerOfNation = 0.0;
        foreach (var bender in EarthBenders)
        {
            powerOfNation += bender.Power * bender.GroundSaturation;
        }

        var monumentsPower = 0.0;

        foreach (var monument in EarthMonuments)
        {
            monumentsPower += monument.EarthAffinity;
        }

        var totalPower = (powerOfNation / 100) * monumentsPower;
        totalPower += powerOfNation;
        return totalPower;
    }

    public void DeleteNation()
    {
        this.EarthBenders.Clear();
        this.EarthMonuments.Clear();
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Earth Nation");
            
        if (EarthBenders.Count <= 0)
        {
            sb.AppendLine("Benders: None");
        }
        else
        {
            sb.AppendLine("Benders: ");
        }
        foreach (var air in EarthBenders)
        {
            sb.AppendLine($"###Earth Bender: {air.Name}, Power: {air.Power}, Ground Saturation: {air.GroundSaturation:f2}");
        }
       
        if (EarthMonuments.Count <= 0)
        {
            sb.AppendLine("Monuments: None");
        }
        else
        {
            sb.AppendLine("Monuments: ");
            foreach (var air in EarthMonuments)
            {
                sb.AppendLine($"###Earth Monument: {air.Name}, Earth Affinity: {air.EarthAffinity}");
            }
        }

        return sb.ToString();
    }
}

