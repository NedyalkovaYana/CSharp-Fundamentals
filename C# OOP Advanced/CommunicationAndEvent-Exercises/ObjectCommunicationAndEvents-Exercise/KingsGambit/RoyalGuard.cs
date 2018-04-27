
using System;

public class RoyalGuard : Solider
{
    public RoyalGuard(string name) 
        : base(name)
    {
        this.Name = name;
    }
    public string Name { get; }
    public override void KingUnderAttack(object sender, EventArgs e)
    {
        Console.WriteLine($"Royal Guard {this.Name} is defending!");
    }
}

