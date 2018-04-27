using System.Collections.Generic;

public abstract class IMinder
{
    private string name;
    private List<Animal> storedAnimals;

    public List<Animal> StoredAnimals
    {
        get { return this.storedAnimals; }
        protected set { this.storedAnimals = value; }
    }

    protected IMinder(string name)
    {
        this.Name = name;
        this.StoredAnimals = new List<Animal>();
    }

    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }
}

