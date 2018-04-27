class Hen : Bird
{
    private const double weightConst = 0.35;
    public Hen(string animalName, double animalWeight, double wingSize) 
        : base(animalName, animalWeight, wingSize)
    {
    }

    public override string MakeSound()
    {
        return $"Cluck";
    }

    public override void FeedAnimal(Food food)
    {
        this.AnimalWeight += (food.Quantity * weightConst);
        this.FoodEaten += food.Quantity;
    }
}

