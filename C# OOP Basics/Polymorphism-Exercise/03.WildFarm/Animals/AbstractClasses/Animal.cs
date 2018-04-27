using System;

public abstract class Animal 
{
    private string animalName;
    private double animalWeight;
    protected Animal(string animalName,  double animalWeight)
    {
        this.AnimalName = animalName;
        this.AnimalWeight = animalWeight;
        
    }

    public string AnimalName { get; private set; }
    public double AnimalWeight { get; set; }
    public int FoodEaten { get; set; }

    public abstract string MakeSound();
    public abstract void FeedAnimal(Food food);
    public abstract string ToString();

}
