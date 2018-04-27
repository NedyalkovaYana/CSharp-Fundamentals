public abstract class Bird : Animal
{
    private double wingSize;

    protected Bird(string animalName, double animalWeight, double wingSize)
        : base(animalName, animalWeight)
    {
        this.WingSize = wingSize;
        this.FoodEaten = 0;
    }

    public double WingSize 
    {
        get { return this.wingSize; }
       protected set { this.wingSize = value; }
    }

    public override string ToString()
    {
        return $"{GetType().Name} [{this.AnimalName}, {this.WingSize}, {this.AnimalWeight}, {this.FoodEaten}]";
    }
}

