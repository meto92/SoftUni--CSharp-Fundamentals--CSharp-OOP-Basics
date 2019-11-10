using DungeonsAndCodeWizards.Models.Items;
using System.Collections.Generic;

namespace DungeonsAndCodeWizards.Interfaces
{
    public interface IBag
    {
        int Capacity
        {
            get;
        }

        int Load
        {
            get;
        }

        IReadOnlyCollection<Item> Items
        {
            get;
        }

        void AddItem(Item item);

        Item GetItem(string name);
    }
}