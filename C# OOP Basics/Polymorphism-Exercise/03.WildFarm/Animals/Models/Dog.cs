using System;

public class Dog : Feline
{
    private const double weightConst = 0.40;

    public Dog(string animalName, double animalWeight, string livingRegion) 
        : base(animalName, animalWeight, livingRegion)
    {
    }

    public override string MakeSound()
    {
        return $"Woof!";
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

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.AnimalName}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}

