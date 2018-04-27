using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;
    public List<Player> players;

    public Team(string name)
    {
        this.name = name;
        this.players = new List<Player>();
    }
    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrEmpty(value) || value == " ") //??&??
            {
                throw new ArgumentException("A name should not be empty. ");
            }
            name = value;
        }
    }

    public void AddPlayer(Player player)
    {
        this.players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        var findingPlayer = players.FirstOrDefault(p => p.Name == playerName);
        if (findingPlayer == null)
        {
            throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
        }
        players.Remove(findingPlayer);
    }
    public decimal GetRating()
    {
        var rating = 0m;
        var statsCount = 0;
        if (players.Count > 0)
        {
            foreach (var stats in players)
            {
                rating += stats.stats.Sum();
                statsCount = stats.stats.Count;
            }
            rating = rating/statsCount;
        }

        return Math.Round(rating);
    }
}

