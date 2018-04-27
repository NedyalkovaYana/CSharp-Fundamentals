using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Interfaces
{
    public interface IItem
    {
        int Weight { get; }
        void AffectCharacter(ICharacter character);

    }
}
