
using System;

public class Footman : Solider
{
    public Footman(string name) 
        : base(name)
    {
        this.Name = name;
    }
    public string Name { get; }
    public override void KingUnderAttack(object sender, EventArgs e)
    {
        Console.WriteLine($"Footman {this.Name} is panicking!");
    }
}

