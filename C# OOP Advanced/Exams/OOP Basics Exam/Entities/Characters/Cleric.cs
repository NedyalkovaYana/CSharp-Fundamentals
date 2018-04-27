using System;
using DungeonsAndCodeWizards.Entities.Bag;
using DungeonsAndCodeWizards.Exceptions;
using DungeonsAndCodeWizards.Interfaces;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public class Cleric : Character, IHealable
    {
        private const double ConstBaseHealth = 50;
        private const double ConstBaseArmor = 25;
        private const double ConstAbilityPoints = 40;

        public Cleric(string name, Faction faction) :
            base(name, ConstBaseHealth, ConstBaseArmor, ConstAbilityPoints, new Backpack(), faction)
        {
        }
        public override double RestHealMultiplier => 0.5;
        public void Heal(ICharacter character)
        {
            this.EnshureAlive();

            if (!character.IsAlive)
            {
                throw new InvalidOperationException(Messages.MustBeAliveMessage);
            }

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException(Messages.CannotHealEnemy);
            }

            character.Health = Math.Min(character.BaseHealth, character.Health + this.AbilityPoints);
        }
    }
}
