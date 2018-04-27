public abstract class Animal
{
    private string name;
    private int age;
    public bool isClean;

    protected Animal(string name, int age)
    {
        this.Name = name;
        this.Age = age;
        this.isClean = false;
    }
    public int Age
    {
        get { return this.age; }
       protected set { this.age = value; }
    }

    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

}

