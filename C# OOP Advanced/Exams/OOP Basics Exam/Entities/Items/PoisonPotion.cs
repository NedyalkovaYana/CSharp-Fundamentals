using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Interfaces;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public class PoisonPotion : Item
    {
        private const int DefaultWeight = 5;
        private const int DefaltPoints = 20;
        public PoisonPotion() 
            : base(DefaultWeight)
        {
        }

        public override void AffectCharacter(ICharacter character)
        {
            base.AffectCharacter(character);

            character.Health -= DefaltPoints;

            if (character.Health <= 0)
            {
                character.IsAlive = false;
            }
        }
    }
}
