using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag
    {
        private const int DefaultCapacity = 100;

        private int capacity;
        private List<Item> items;

        protected Bag(int capacity = DefaultCapacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public IReadOnlyCollection<Item> Items
        {
            get
            {
                return this.items.AsReadOnly();
            }
        }

        protected long Load => this.items.Sum(i => i.Weight);

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                this.capacity = value;
            }
        }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            if (!this.items.Any(i => i.GetType().Name == name))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            Item item = this.items.FirstOrDefault(i => i.ToString() == name);
            this.items.Remove(item);
            return item;
        }
    }
}