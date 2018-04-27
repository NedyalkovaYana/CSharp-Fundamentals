using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Items;

namespace DungeonsAndCodeWizards.Interfaces
{
    public interface ICharacter
    {
        string Name { get; }
        double Health { get; set; }
        double BaseHealth { get; }
        double BaseArmor { get; }
        double Armor { get; set; }
        double AbilityPoints { get; }
        IBag Bag { get; }
        Faction Faction { get; }

        bool IsAlive { get; set; }
        double RestHealMultiplier { get; }
        void TakeDamage(double hitPoints);
        void Rest();
        void UseItem(IItem item);

        void UseItemOn(IItem item, ICharacter character);
        void GiveCharacterItem(IItem item, ICharacter character);
        void ReceiveItem(IItem item);
        string CharacterToString();
    }
}
