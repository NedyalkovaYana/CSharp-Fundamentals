using System;

public class Mouse : Mammal
{
    private const double weightConst = 0.10;
    public Mouse(string animalName, double animalWeight, string livingRegion) 
        : base(animalName, animalWeight, livingRegion)
    {
    }

    public override void FeedAnimal(Food food)
    {
        if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Fruit")
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
        this.AnimalWeight += (food.Quantity * weightConst);
        this.FoodEaten += food.Quantity;
    }

    public override string MakeSound()
    {
        return $"Squeak";
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.AnimalName}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
