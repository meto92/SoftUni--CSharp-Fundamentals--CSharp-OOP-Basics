using System;
using System.Linq;
using System.Collections.Generic;

using DungeonsAndCodeWizards.Interfaces;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag : IBag
    {
        private const int DefaultBagCapacity = 100;

        private const string EmptyBagExceptionMessage = "Bag is empty!";
        private const string BagFullExceptionMessage = "Bag is full!";
        private const string NoItemWithThatNameExceptionMessage = "No item with name {0} in bag!";

        private int capacity;
        private List<Item> items;

        protected Bag(int capacity = DefaultBagCapacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity
        {
            get => this.capacity;
            private set => this.capacity = value;
        }

        public int Load => this.Items.Sum(item => item.Weight);

        public IReadOnlyCollection<Item> Items => this.items;

        public void AddItem(Item item)
        {
            if (item.Weight + this.Load > this.Capacity)
            {
                throw new InvalidOperationException(BagFullExceptionMessage);
            }
            
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(EmptyBagExceptionMessage);
            }

            Item item = this.items
                .FirstOrDefault(i => i.Name == name);

            if (item == null)
            {
                throw new ArgumentException(string.Format(
                    NoItemWithThatNameExceptionMessage,
                    name));
            }

            this.items.Remove(item);

            return item;
        }
    }
}