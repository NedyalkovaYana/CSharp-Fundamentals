using System;
using System.Collections.Generic;
using System.Net;

public class Player
{
    
    private string name;
    public List<decimal> stats;
    private List<string> statsName = new List<string> {"Endurance", "Sprint", "Dribble", "Passing", "Shooting"};
    public Player(string name)
    {
        this.Name = name;
        this.stats = new List<decimal>();
    }
    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrEmpty(value) || value == " ")
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }
 
    public void AddStats(List<decimal> stats)
    {

        for(int i = 0; i < stats.Count; i++)
        {
            if (stats[i] < 0 || stats[i] > 100)
            {
                throw new ArgumentException($"{statsName[i]} should be between 0 and 100.");
            }
            this.stats.Add(stats[i]);
        }
        
    }
}

