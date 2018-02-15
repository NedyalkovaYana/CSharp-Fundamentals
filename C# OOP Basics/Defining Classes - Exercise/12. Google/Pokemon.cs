﻿public class Pokemon
{
    //pokemon<pokemonName> <pokemonType>”
    private string name;
    private string type;

    public Pokemon(string name, string type)
    {
        this.name = name;
        this.type = type;
    }
    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Type}";
    }
}

