using System;

public class Owl : Bird
{
    private const double weightConst = 0.25;
    public Owl(string animalName, double animalWeight,  double wingSize) 
        : base(animalName, animalWeight, wingSize)
    {
    }

    public override string MakeSound()
    {
        return $"Hoot Hoot";
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

