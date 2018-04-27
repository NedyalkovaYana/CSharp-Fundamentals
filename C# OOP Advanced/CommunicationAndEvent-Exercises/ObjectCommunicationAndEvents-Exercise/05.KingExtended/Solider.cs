
using System;
public delegate void SoldierDeathEventHandler(object sender, SoliderDeathEventArgs args);
public abstract class Solider : IName
{
    public event SoldierDeathEventHandler SoliderDeath;
    public Solider(string name, int hitLeft)
    {
        this.Name = name;
        this.HitLeft = hitLeft;
    }
    public string Name { get; }
    protected int HitLeft { get; set; }
    public abstract void KingUnderAttack(object sender, EventArgs e);
    public void RespondToAttack()
    {
        this.HitLeft--;
        if (this.HitLeft == 0)
        {
            OnSoliderDeath(new SoliderDeathEventArgs(this.Name, KingUnderAttack));
        }
    }

    protected void OnSoliderDeath(SoliderDeathEventArgs args)
    {
        if (SoliderDeath != null)
        {
            SoliderDeath(this, args);
        }
    }   
}

