public class Parents
{
    //parentName> <parentBirthday>”
    private string name;
    private string birthday;

    public Parents(string name, string birthday)
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

