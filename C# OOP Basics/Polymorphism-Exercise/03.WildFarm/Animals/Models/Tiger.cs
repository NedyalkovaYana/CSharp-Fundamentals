using System;

public  class Tiger : Feline
{
    private const double weightConst = 1.00;

    public Tiger(string animalName, double animalWeight, string livingRegion, string breed) 
        : base(animalName, animalWeight, livingRegion, breed)
    {
    }

    public override string MakeSound()
    {
        return "ROAR!!!";
    }

    public override void FeedAnimal(Food food)
    {
        if (food.GetType().Name != "Meat")
        {
            throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
        }

        this.AnimalWeight += (food.Quantity * weightConst);
        this.FoodEaten += food.Quantity;
    }
}

