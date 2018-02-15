using System.Collections.Generic;
using System.Linq;

public class Trainer
{
    //name, number of badges and a collection of pokemon
    public string name;
    public int numberofBadges;
    public List<Pokemon> pokemonList;

    public Trainer(string name)
    {
        this.name = name;
        this.numberofBadges = 0;
        this.pokemonList = new List<Pokemon>();
    }

    public void DeleteDeadPokemons()
    {
        if (this.pokemonList.Count > 0 && this.pokemonList.Where(p => p.Health <= 0).FirstOrDefault() != null)
        {
            this.pokemonList = new List<Pokemon>(this.pokemonList.Where(p => p.Health > 0)).ToList();
        }
    }

    public void AddBadage()
    {
        this.numberofBadges++;
    }
}

