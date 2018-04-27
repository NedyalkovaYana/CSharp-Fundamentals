public abstract class Feline : Mammal
{
    private string breed;

    public string Breed { get; private set; }

    public Feline(string animalName, double animalWeight, string livingRegion)
        : base(animalName, animalWeight, livingRegion)
    {
    }
    public Feline(string animalName, double animalWeight, string livingRegion, string breed)
        : base(animalName, animalWeight, livingRegion)
    {
        this.Breed = breed;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.AnimalName}, {this.Breed}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
    


