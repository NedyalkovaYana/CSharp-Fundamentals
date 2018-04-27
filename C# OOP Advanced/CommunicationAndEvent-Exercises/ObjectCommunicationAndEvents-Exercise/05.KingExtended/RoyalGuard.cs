
using System;

public class RoyalGuard : Solider
{
    private const int RoyalGuardHits = 3;
    public RoyalGuard(string name) 
        : base(name, RoyalGuardHits)
    {
        this.Name = name;
    }
    public string Name { get; }
    public override void KingUnderAttack(object sender, EventArgs e)
    {
        Console.WriteLine($"Royal Guard {this.Name} is defending!");
    }
}

