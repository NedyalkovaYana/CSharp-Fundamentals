using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Exceptions;
using DungeonsAndCodeWizards.Interfaces;

namespace DungeonsAndCodeWizards.Entities.Items
{
   public abstract class Item : IItem
   {
       private int weight;
       protected Item(int weight)
       {
           this.Weight = weight;
       }
        public int Weight { get; }
        public virtual void AffectCharacter(ICharacter character)
        {
            try
            {
                if (!character.IsAlive)
                {
                    throw new InvalidOperationException(Messages.MustBeAliveMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
