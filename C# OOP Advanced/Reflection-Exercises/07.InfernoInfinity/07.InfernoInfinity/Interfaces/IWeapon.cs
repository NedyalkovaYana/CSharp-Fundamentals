
public interface IWeapon
{
    string Name { get; }
    Rarity Rarity { get; }
    int MaxDamage { get; }
    int MinDamage { get; }

    IGem[] GemStock { get; }

    void AddGem(IGem gem, int stockedIndex);
    void RemoveGem(int stokedIndex);
}

