using System.Collections.Generic;
using System.Text;

public  class WaterNation
{
    public List<WaterBender> WaterBenders { get; set; }
    public List<WaterMonument> WaterMonuments { get; set; }

    public WaterNation()
    {
        this.WaterBenders = new List<WaterBender>();
        this.WaterMonuments = new List<WaterMonument>();
    }

    public void AddWaterBender(WaterBender waterBender)
    {
        this.WaterBenders.Add(waterBender);
    }

    public void AddWaterMonument(WaterMonument waterMonument)
    {
        this.WaterMonuments.Add(waterMonument);
    }

    public double GetTotalPower()
    {
        var powerOfNation = 0.0;
        foreach (var bender in WaterBenders)
        {
            powerOfNation += bender.Power * bender.WaterClarity;
        }

        var monumentsPower = 0.0;

        foreach (var monument in WaterMonuments)
        {
            monumentsPower += monument.WaterAffinity;
        }

        var totalPower = (powerOfNation / 100) * monumentsPower;
        totalPower += powerOfNation;
        return totalPower;
    }

    public void DeleteNation()
    {
        this.WaterMonuments.Clear();
        this.WaterBenders.Clear();
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Water Nation");
        if (WaterBenders.Count <= 0)
        {
            sb.AppendLine("Benders: None");
        }
        else
        {
            sb.AppendLine("Benders:");
        }

        foreach (var air in WaterBenders)
        {
            sb.AppendLine($"###Water Bender: {air.Name}, Power: {air.Power}, Water Clarity: {air.WaterClarity:f2}");
        }
       
        if (WaterMonuments.Count <= 0)
        {
            sb.AppendLine("Monuments: None");
        }
        else
        {
            sb.AppendLine("Monuments:");
            foreach (var air in WaterMonuments)
            {

                sb.AppendLine($"###Water Monument: {air.Name}, Water Affinity: {air.WaterAffinity}");
            }
        }

        return sb.ToString();
    }
}

