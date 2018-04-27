
using System;
using System.Linq;

public abstract class Weapon : IWeapon
{
    protected Weapon(string name, Rarity rarity, int maxDamage, int minDamage, 
        int numbersOfGemStocks)
    {
        this.Name = name;
        this.Rarity = rarity;
        this.MaxDamage = maxDamage * (int)rarity;
        this.MinDamage = minDamage * (int)rarity;
        this.GemStock = new IGem[numbersOfGemStocks];

    }

    public string Name { get; private set; }
    public Rarity Rarity { get; private set; }
    public int MaxDamage { get; private set; }
    public int MinDamage { get; private set; }
    public IGem[] GemStock { get; private set; }

    public void AddGem(IGem gem, int GemStockedIndex)
    {
        if (GemStockedIndex >= 0 && GemStockedIndex < this.GemStock.Length)
        {
            this.GemStock[GemStockedIndex] = gem;
        }
    }

    public void RemoveGem(int stokedIndex)
    {
        if (stokedIndex >= 0 && stokedIndex < this.GemStock.Length)
        {
            this.GemStock[stokedIndex] = null;
        }
    }

    public override string ToString()
    {
        var strength = this.GemStock.Where(g => g != null).Select(g => g.StrenghtBonus).Sum();
        var agility = this.GemStock.Where(g => g != null).Select(g => g.AgilityBonus).Sum();
        var vitality = this.GemStock.Where(g => g != null).Select(g => g.VatilityBonus).Sum();

        var minDamage = this.MinDamage + (strength * 2) + agility;
        var maxDamage = this.MaxDamage + (strength * 3) + (agility * 4);

        return $"{this.Name}: {minDamage}-{maxDamage} Damage, +{strength} Strength, +{agility} Agility, +{vitality} Vitality";
    }
}

