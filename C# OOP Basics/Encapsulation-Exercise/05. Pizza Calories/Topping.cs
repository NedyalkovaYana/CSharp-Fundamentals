using System;

public class Topping
{      
    private const double MeatType = 1.2;
    private const double VeggiesType = 0.8;
    private const double CheeseType = 1.1;
    private const double SauceType = 0.9;

    private string toppingType;
    private double  weight;

    public Topping(string toppingType, double weight)
    {
        this.ToppingType = toppingType;
        this.Weight = weight;
    }

    public double Weight
    {
        get { return weight; }
        private set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.ToppingType} weight should be in the range[1..50].");
            }
            weight = value;
        }
    }

    public string ToppingType
    {
        get { return toppingType; }
        private set
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies"
                && value.ToLower() != "cheese" && value.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            toppingType = value;
        }
    }

    public double GetCalories()
    {
        var calories =  2 * this.weight;

        switch (this.ToppingType.ToLower())
        {
            case "meat":
                return calories *= MeatType;
            case "veggies":
                return calories *= VeggiesType;
            case "cheese":
                return calories *= CheeseType;
            case "sauce":
                return calories *= SauceType;
        }
        return calories;
    }
}

