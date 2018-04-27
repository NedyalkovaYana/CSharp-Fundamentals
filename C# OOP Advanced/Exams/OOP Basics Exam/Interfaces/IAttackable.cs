using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Interfaces
{
   public interface IAttackable
   {
       void Attack(ICharacter character);
   }
}
