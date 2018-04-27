using System;

public class Dough
{
    private const double WhiteType = 1.5;
    private const double WholegrainType = 1.0;
    private const double CrispyType = 0.9;
    private const double ChewyType = 1.1;
    private const double HomeMadeType = 1.0;

    private string flourType;
    private string bakingTechnique;
    private double weight;

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }
    public double Weight
    {
        get { return weight; }
        private set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException
                    ("Dough weight should be in the range [1..200].");
            }
            weight = value;
        }
    }


    public string BakingTechnique
    {
        get { return bakingTechnique; }
        private set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy"
                && value.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            bakingTechnique = value;
        }
    }

    public string FlourType
    {
        get { return flourType; }
        private set
        {
            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            flourType = value;
        }
    }

    public double CalcCalories()
    {
        var calories = 2 * this.Weight;

        if (this.FlourType.ToLower() == "white")
        {
            calories *= WhiteType;
        }
        else
        {
            calories *= WholegrainType;
        }

        switch (this.BakingTechnique.ToLower())
        {
            case "crispy":
                calories *= CrispyType;
                break;
            case "chewy":
                calories *= ChewyType;
                break;
            case "homemade":
                calories *= HomeMadeType;
                break;
        }

        return calories;
    }
}

