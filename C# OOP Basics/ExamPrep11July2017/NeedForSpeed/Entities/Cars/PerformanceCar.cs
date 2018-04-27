using System;
using System.Collections.Generic;

public class PerformanceCar : Car
{
 
    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, 
        int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, 
            durability)
    {

        this.Horsepower += (horsepower * 50)/100;
        this.Suspension = suspension - (suspension * 25) / 100;
        this.AddOns = new List<string>();
    }

    public override string ToString()
    {
        if (AddOns.Count <= 0)
        {
            return base.ToString() + $"Add-ons: None";
        }
        return base.ToString() + $"Add-ons: {string.Join(", ", AddOns)}";
    }
}

