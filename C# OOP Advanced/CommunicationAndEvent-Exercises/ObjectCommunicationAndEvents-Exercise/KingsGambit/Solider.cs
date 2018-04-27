
using System;

public abstract class Solider : IName
{
    public Solider(string name)
    {
        this.Name = name;
    }
    public string Name { get; }

    public abstract void KingUnderAttack(object sender, EventArgs e);
}

