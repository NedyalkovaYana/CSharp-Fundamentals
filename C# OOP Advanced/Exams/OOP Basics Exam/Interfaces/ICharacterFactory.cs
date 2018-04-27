using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Interfaces
{
    public interface ICharacterFactory
    {
        ICharacter CreateCharacter(IList<string> args);
    }
}
