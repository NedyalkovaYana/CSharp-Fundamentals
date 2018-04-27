public class Ferrari : ICar
{
    public const string Model = "488-Spider";
    public string Name { get; private set; }

    public Ferrari(string name)
    {
        Name = name;
    }

    public string Start()
    {
        return "Zadu6avam sA!";
    }

    public string Stop()
    {
        return "Brakes!";
    }

    public override string ToString()
    {
        return $"{Model}/{this.Stop()}/{this.Start()}/{this.Name}";
    }
}

