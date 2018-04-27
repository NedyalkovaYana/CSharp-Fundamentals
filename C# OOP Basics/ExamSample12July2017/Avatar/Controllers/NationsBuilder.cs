using System;
using System.Collections.Generic;
using System.Text;

public class NationsBuilder
{
    AirNation airNation = new AirNation();
    WaterNation waterNation = new WaterNation();
    FireNation fireNation = new FireNation();
    EarthNation earthNation = new EarthNation();
    public List<string> wars = new List<string>();

    public void AssignBender(List<string> benderArgs)
    {
        var benderType = benderArgs[1];
        switch (benderType)
        {
            case "Air":
                var air = new AirBender(benderArgs[2], int.Parse(benderArgs[3]), double.Parse(benderArgs[4]));
                airNation.AddAirBenders(air);
                break;
            case "Water":
                var water = new WaterBender(benderArgs[2], int.Parse(benderArgs[3]), double.Parse(benderArgs[4]));
                waterNation.AddWaterBender(water);
                break;
            case "Fire":
                var fire = new FireBender(benderArgs[2], int.Parse(benderArgs[3]), double.Parse(benderArgs[4]));
                fireNation.AddFireBender(fire);
                break;
            case "Earth":
                var earth = new EarthBender(benderArgs[2], int.Parse(benderArgs[3]), double.Parse(benderArgs[4]));
                earthNation.AddEarthBender(earth);
                break;
        }
    }
    public void AssignMonument(List<string> monumentArgs)
    {
        var monumentType = monumentArgs[1];
        var name = monumentArgs[2];
        var affinity = int.Parse(monumentArgs[3]);
        switch (monumentType)
        {
            case "Air":
               var airMonument = new AirMonument(name, affinity);
                airNation.AddAirMonument(airMonument);
                break;
            case "Water":
               var waterMonument = new WaterMonument(name, affinity);
                waterNation.AddWaterMonument(waterMonument);
                break;
            case "Fire":
              var fireMonument = new FireMonument(name, affinity);
                fireNation.AddFireMonument(fireMonument);
                break;
            case "Earth":
              var eartMonument = new EarthMonument(name, affinity);
                earthNation.AddEartMonument(eartMonument);
                break;
        }
    }
    public string GetStatus(string nationsType)
    {
        switch (nationsType)
        {
            case "Fire":
                return fireNation.ToString();
            case "Air":
                return airNation.ToString();
            case "Water":
                return waterNation.ToString();
            case "Earth":
                return earthNation.ToString();
                default:
                    return "";
        }

    }
    public void IssueWar(string nationsType)
    {
        wars.Add(nationsType);
        var airNationPower = airNation.GetTotalPower();
        var waterNationPower = waterNation.GetTotalPower();
        var fireNationPower = fireNation.GetTotalPower();
        var earthNationPower = earthNation.GetTotalPower();

        var winnerOne = Math.Max(airNationPower, earthNationPower);
        var winnerTwo = Math.Max(waterNationPower, fireNationPower);

        var winner = Math.Max(winnerTwo, winnerOne);
        if (airNationPower < winner)
        {
            airNation.DeleteNation();
        }
        else if (waterNationPower < winner)
        {
            waterNation.DeleteNation();
        }
        else if (fireNationPower < winner)
        {
            fireNation.DeleteNation();
        }
        else if ( earthNationPower < winner)
        {
            earthNation.DeleteNation();
        }

    }
    public  string GetWarsRecord()
    {
        var sb = new StringBuilder();
        var count = 1;
        foreach (var war in wars)
        {
            sb.AppendLine($"War {count} issued by {war}");
            count++;
        }

        return sb.ToString().Trim();
    } 

}

