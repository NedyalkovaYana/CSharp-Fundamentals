public class Citizen : IByer
{
    private string name;
    private int age;
    private string id;
    private string birthday;
    public int Food { get; private set; }

    public Citizen(string name, int age, string id, string birthday)
    {
        this.name = name;
        this.age = age;
        this.id = id;
        this.birthday = birthday;
    }

    public string Birthday
    {
        get { return birthday; }
        private set { birthday = value; }
    }

    public string Id
    {
        get { return id; }
        private set { id = value; }
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
        this.Food += 10;
    }
}

