public class Rebel : IByer
{
    private string name;
    private int age;
    private string group;
    public int Food { get; private set; }

    public Rebel(string name, int age, string @group)
    {
        this.name = name;
        this.age = age;
        this.@group = @group;
    }
    public string Group
    {
        get { return group; }
        set { group = value; }
    }

    public int Age
    {
        get { return age; }
       private set { age = value; }
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }    
    public void BuyFood()
    {
        this.Food += 5;
    }
}

