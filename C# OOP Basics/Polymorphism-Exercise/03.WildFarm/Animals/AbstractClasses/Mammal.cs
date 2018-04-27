
public abstract class Mammal : Animal
{
    private string livingRegion;
    public string LivingRegion { get; protected set; }

    public Mammal(string animalName, double animalWeight)
        : base(animalName, animalWeight)
    {
       
    }
    public Mammal(string animalName, double animalWeight, string livingRegion) 
        : base(animalName, animalWeight)
    {
        this.LivingRegion = livingRegion;
    }
}

