using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Interfaces
{
    public interface IHealable
    {
        void Heal(ICharacter character);
    }
}
