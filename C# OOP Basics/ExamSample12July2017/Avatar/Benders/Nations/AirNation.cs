using System;
using System.Collections.Generic;
using System.Text;

public  class AirNation
{
    public List<AirBender> AirBenders { get; set; }
    public List<AirMonument> AirMonuments { get; set; }

    public AirNation()
    {
        this.AirBenders = new List<AirBender>();
        this.AirMonuments = new List<AirMonument>();
    }

    public void AddAirBenders(AirBender airBender)
    {
        this.AirBenders.Add(airBender);
    }

    public void AddAirMonument(AirMonument airMonument)
    {
        this.AirMonuments.Add(airMonument);
    }

    public double GetTotalPower()
    {
        var powerOfNation = 0.0;
        foreach (var airBender in AirBenders)
        {
            powerOfNation += airBender.Power * airBender.AerialIntegrity;
        }

        var monumentsPower = 0.0;

        foreach (var airMonument in AirMonuments)
        {
            monumentsPower += airMonument.AirAffinity;
        }

        var totalPower = (powerOfNation / 100) * monumentsPower;
        totalPower += powerOfNation;
        return totalPower;
    }

    public void DeleteNation()
    {
        this.AirBenders.Clear();
        this.AirMonuments.Clear();
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Air Nation");
           
        if (AirBenders.Count <= 0)
        {
            sb.AppendLine("Benders: None");
        }
        else
        {
            sb.AppendLine("Benders: ");
        }
        foreach (var air in AirBenders)
        {
            sb.AppendLine($"###Air Bender: {air.Name}, Power: {air.Power}, Aerial Integrity: {air.AerialIntegrity:f2}");
        }
        
        if (AirMonuments.Count <= 0)
        {
            sb.AppendLine("Monuments: None");
        }
        else
        {
            sb.AppendLine("Monuments: ");
            foreach (var air in AirMonuments)
            {
                sb.Append($"###Air Monument: {air.Name}, Air Affinity: {air.AirAffinity}");
            }
        }

        return sb.ToString();
    }
}

