public abstract class Animal : IAnimals
{
    public string Name { get; private set; }
    public string FavoriteFood { get; private set; }

    protected Animal(string name, string favoriteFood)
    {
        Name = name;
        FavoriteFood = favoriteFood;
    }

    public virtual string ExplainMyself()
    {
        return $"I am {this.Name} and my fovourite food is {this.FavoriteFood}";
    }
}

