using System;
public class Cat : Feline
{
    private const double weightConst = 0.30;

    public Cat(string animalName, double animalWeight, string livingRegion, string breed) 
        : base(animalName, animalWeight, livingRegion, breed)
    {
    }

    public override void FeedAnimal(Food food)
    {
        if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Meat")
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        this.AnimalWeight += (food.Quantity * weightConst);
        this.FoodEaten += food.Quantity;
    }

    public override string MakeSound()
    {
        return "Meow";
    }

   
}

