
using System;

public class Footman : Solider
{
    private const int FootmanHits = 2;
    public Footman(string name) 
        : base(name, FootmanHits)
    {
        this.Name = name;
    }
    public string Name { get; }
    public override void KingUnderAttack(object sender, EventArgs e)
    {
        Console.WriteLine($"Footman {this.Name} is panicking!");
    }
}

