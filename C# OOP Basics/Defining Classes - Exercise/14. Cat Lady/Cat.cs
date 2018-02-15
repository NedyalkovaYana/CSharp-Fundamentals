public class Cat
{
    private string breed;
    private string name;
    private string specific;

    public Cat(string breed, string name, string specific)
    {
        this.breed = breed;
        this.name = name;
        this.specific = specific;
    }
    public string Specific
    {
        get { return specific; }
        set { specific = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }


    public string Breed
    {
        get { return breed; }
        set { breed = value; }
    }

    public override string ToString()
    {
        if (this.Breed == "Cymric")
        {
            return $"{this.Breed} {this.Name} {this.Specific:f2}";
        }
        else
        {
            return $"{this.Breed} {this.Name} {this.Specific}";
        }       
    }
}

