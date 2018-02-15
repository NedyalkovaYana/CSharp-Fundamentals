public class Children
{
    //childName> <childBirthday>”
    private string name;
    private string birthday;

    public Children(string name, string birthday)
    {
        this.name = name;
        this.birthday = birthday;
    }
    public string Birthday
    {
        get { return birthday; }
        set { birthday = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Birthday}";
    }
}

