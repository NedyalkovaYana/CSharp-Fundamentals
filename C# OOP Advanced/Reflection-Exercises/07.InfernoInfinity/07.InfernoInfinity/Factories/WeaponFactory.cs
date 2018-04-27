using System;

public class WeaponFactory
{
    internal IWeapon CreateWeapon(string weaponKind, string weaponName, string weaponRarity)
    {
        Rarity rarity;
        var isRarityValid = Enum.TryParse(weaponRarity, out rarity);

        if (!isRarityValid)
        {
            return null;
        }

        switch (weaponKind)
        {
            case "Axe":
                return new Axe(weaponName, rarity);
            case "Sword":
                return new Sword(weaponName, rarity);
            case "Knife":
                return new Knife(weaponName, rarity);
            default:
                return null;
        }
    }
}

