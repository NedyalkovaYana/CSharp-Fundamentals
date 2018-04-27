using System.Collections.Generic;

namespace DungeonsAndCodeWizards.Interfaces
{
    public interface IBag
    {
        int Capacity { get;  set; }
        double Load();
        IReadOnlyCollection<IItem> Items { get; }

        void AddItem(IItem item);
        IItem GetItem(string name);

    }

}
