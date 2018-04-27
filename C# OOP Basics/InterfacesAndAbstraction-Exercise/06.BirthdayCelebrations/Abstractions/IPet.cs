public abstract class IPet
{
    private string name;
    private string birthday;

    protected IPet(string name, string birthday)
    {
        this.Name = name;
        this.Birthday = birthday;
    }

    public string Birthday
    {
        get { return this.birthday; }
        private set { this.birthday = value; }
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }
}

