using System.ComponentModel;

public class Pokemon
{
    //name, an element and health
    private string name;
    private string element;
    private int health;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }
    public string Element
    {
        get { return this.element; }
        set { this.Element = value; }
    }
    public int Health
    {
        get { return this.health; }
        set { this.health = value; }
    }

    public Pokemon(string name, string element, int health)
    {
        this.name = name;
        this.element = element;
        this.health = health;
    }

    public void DecreaseHealth()
    {
        this.Health -= 10;
    }

}

