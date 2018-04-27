﻿
public class Axe : Weapon
{
    private const int MaxDamage = 10;
    private const int MinDamage = 5;
    private const int GemSockets = 4;
    public Axe(string name, Rarity rarity)
        : base(name, rarity, MaxDamage, MinDamage, GemSockets)
    {
    }
}

