using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public class StartUp
{
    static void Main()
    {
        var trainersList = new List<Trainer>();

        var inputInfo = string.Empty;
        while ((inputInfo = Console.ReadLine()) != "Tournament")
        {
            var infoTokens = inputInfo.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            //<TrainerName> <PokemonName> <PokemonElement> <PokemonHealth>
            var trainerName = infoTokens[0];
            var pokemonName = infoTokens[1];
            var pokemonElement = infoTokens[2];
            var pokemonHealth = int.Parse(infoTokens[3]);
            var catchedPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            var currentTrainer = trainersList.Where(t => t.name == trainerName).FirstOrDefault();
            if (currentTrainer == null)
            {
                currentTrainer = new Trainer(trainerName);
                trainersList.Add(currentTrainer);
            }
            currentTrainer.pokemonList.Add(catchedPokemon);

        }

        var elementToSearch = string.Empty;
        while ((elementToSearch = Console.ReadLine().Trim()) != "End")
        {
            foreach (var trainer in trainersList)
            {
                if (trainer.pokemonList.Where(e => e.Element == elementToSearch).FirstOrDefault() == null)
                {
                    foreach (var pokemon in trainer.pokemonList)
                    {
                         pokemon.DecreaseHealth();
                        
                    }
                    trainer.DeleteDeadPokemons();
                }
                else
                {
                    trainer.AddBadage();
                }
            }
        }

        Console.WriteLine(string.Join(Environment.NewLine, trainersList
            .OrderByDescending(a => a.numberofBadges)
            .Select(t => $"{t.name} {t.numberofBadges} {t.pokemonList.Count}")));
    }
}

