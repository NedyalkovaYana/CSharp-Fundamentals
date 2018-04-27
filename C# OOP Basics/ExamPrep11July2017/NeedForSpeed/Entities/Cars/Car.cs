using System.Collections.Generic;
using System.Text;

public abstract class Car
{ 
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsepower;
    private int acceleration;
    private int suspension;
    private int durability;
    private int performance;

    protected Car(string brand, string model, int yearOfProduction, int horsepower, 
        int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.Horsepower = horsepower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
        this.Performance = 0;
        this.Stars = 0;
    }
    public int Performance
    {
        get { return performance; }
        set { performance = value; }
    }
    public int Durability
    {
        get { return durability; }
        set { durability = value; }
    }

    public int Suspension
    {
        get { return suspension; }
        set { suspension = value; }
    }

    public int Acceleration
    {
        get { return acceleration; }
        set { acceleration = value; }
    }

    public int Horsepower
    {
        get { return horsepower; }
        set { horsepower = value; }
    }

    public int YearOfProduction
    {
        get { return yearOfProduction; }
       protected set { yearOfProduction = value; }
    }

    public string Model
    {
        get { return model; }
        protected set { model = value; }
    }

    public string Brand
    {
        get { return brand; }
        protected set { brand = value; }
    }

    public List<string> AddOns { get; set; }
    public int Stars { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}")
          .AppendLine($"{this.Horsepower} HP, 100 m/h in {this.Acceleration} s")
          .AppendLine($"{this.Suspension} Suspension force, {this.Durability} Durability");

        return sb.ToString();
    }
   
}

