using System;

public abstract class Ammunition : IAmmunition
{
    private const int ConstForWearLevel = 100;
    private string name;
    private double weight;

    protected Ammunition(double weight)
    {
        this.Weight = weight;
        this.WearLevel = this.Weight * ConstForWearLevel;
    }

    public string Name => this.GetType().Name;
  
    public double Weight
    {
        get { return this.weight; }
        private set { this.weight = value; }
    }

    public double WearLevel { get; private set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}

