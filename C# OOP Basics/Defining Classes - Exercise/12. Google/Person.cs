using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public class Person
{
    //•	“<Name> company <companyName> <department> <salary>”  
    //“<Name> pokemon<pokemonName> <pokemonType>”
    //“<Name> parents<parentName> <parentBirthday>”
    //“<Name> children<childName> <childBirthday>”
    //“<Name> car<carModel> <carSpeed>”

    private string name;
    private Company company;
    private List<Pokemon> pokemon;
    private List<Parents> parents;
    private List<Children> children;
    private Car car;

    public Person(string name)
    {
        this.name = name;  
        this.pokemon = new List<Pokemon>();
        this.parents = new List<Parents>();
        this.children = new List<Children>();
    }
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public void AddCompany(Company company)
    {
        this.company = company;
    }

    public void AddCar(Car car)
    {
        this.car = car;
    }

    public void AddPokemon(Pokemon pokemon)
    {
        this.pokemon.Add(pokemon);
    }

    public void AddParents(Parents parents)
    {
        this.parents.Add(parents);
    }

    public void AddChildren(Children children)
    {
        this.children.Add(children);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(this.name);

        sb.AppendLine("Company:");
        if (this.company != null)
        {
            sb.AppendLine(this.company.ToString());
        }

        sb.AppendLine("Car:");
        if (this.car != null)
        {
            sb.AppendLine(this.car.ToString());
        }

        sb.AppendLine("Pokemon:");
        if (this.pokemon.Count > 0)
        {
            sb.AppendLine(string.Join(Environment.NewLine, this.pokemon.Select(pok => pok.ToString())));
        }

        sb.AppendLine("Parents:");
        if (this.parents.Count > 0)
        {
            sb.AppendLine(string.Join(Environment.NewLine, this.parents.Select(par => par.ToString())));
        }

        sb.AppendLine("Children:");
        if (this.children.Count > 0)
        {
            sb.AppendLine(string.Join(Environment.NewLine, this.children.Select(c => c.ToString())));
        }

        return sb.ToString();
    }
}

