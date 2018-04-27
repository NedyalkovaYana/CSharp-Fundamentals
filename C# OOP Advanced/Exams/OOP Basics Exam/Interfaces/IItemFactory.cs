using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Interfaces
{
    public interface IItemFactory
    {
        IItem CreateItem(IList<string> args);
    }
}
