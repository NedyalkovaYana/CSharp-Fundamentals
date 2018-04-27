using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Exceptions;
using DungeonsAndCodeWizards.Interfaces;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory : IItemFactory
    {
        private Type[] itemTypes;

        public ItemFactory()
        {
            this.itemTypes = new TypeCollector().GetAllInheritingTypes<IItem>();
        }

        public IItem CreateItem(IList<string> args)
        {
            try
            {
                var targetType = itemTypes
                    .FirstOrDefault(t => t.Name.Equals(args[0]));

                if (targetType == null)
                {
                    throw new ArgumentException
                        (string.Format(Messages.InvalidItemType, args[0]));
                }

                return (IItem) Activator.CreateInstance(targetType);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
