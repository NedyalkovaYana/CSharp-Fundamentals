using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entities.Bag;
using DungeonsAndCodeWizards.Exceptions;
using DungeonsAndCodeWizards.Interfaces;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public class Warrior : Character, IAttackable
    {
        private const double ConstBaseHealth = 100;
        private const double ConstBaseArmor = 50;
        private const double ConstAbilityPoints = 40;

        public Warrior(string name, Faction faction)
           : base(name, ConstBaseHealth, ConstBaseArmor, ConstAbilityPoints, new Satchel(), faction)
        {

        }

        public void Attack(ICharacter character)
        {
            this.EnshureAlive();

            if (character == this)
            {
                throw new InvalidOperationException(Messages.CannotAttackSelf);
            }

            if (this.Faction == character.Faction)
            {
                throw new ArgumentException(String.Format(
                    Messages.FrendlyFireMessage, character.Faction));
            }

            character.TakeDamage(AbilityPoints);

        }
    }
}
