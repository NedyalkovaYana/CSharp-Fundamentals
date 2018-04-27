using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Exceptions;
using DungeonsAndCodeWizards.Interfaces;

namespace DungeonsAndCodeWizards.Entities.Bag
{
    public abstract class Bag : IBag
    {
        private const int DefaultBagCapacity = 100;
        private List<IItem> items;
        protected Bag()
        {
            this.Capacity = DefaultBagCapacity;
            this.items = new List<IItem>();
        }

        public int Capacity { get; set; }

        public double Load()
        {
            var loadInItems = 0;

            foreach (var item in Items)
            {
                loadInItems += item.Weight;
            }

            return loadInItems;
        }

        public IReadOnlyCollection<IItem> Items => this.items as IReadOnlyCollection<IItem>;
        public void AddItem(IItem item)
        {
            try
            {
                var currentWeightInItems = this.Load();
                if (currentWeightInItems + item.Weight > DefaultBagCapacity)
                {
                    throw new InvalidOperationException(Messages.BagIsFull);
                }

                this.items.Add(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public IItem GetItem(string name)
        {

            if (items.Count <= 0)
            {
                throw new InvalidOperationException(Messages.BagIsEmpty);
            }

            var findedItem = this.items.FirstOrDefault(i => i.GetType().Name == name);

            if (findedItem == null)
            {
                throw new ArgumentException(String.Format(
                    Messages.NoExistingNameInABag, name));
            }

            items.Remove(findedItem);

            return findedItem;

        }
    }
}
