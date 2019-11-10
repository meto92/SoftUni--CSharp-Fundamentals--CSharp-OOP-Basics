using System;
using System.Linq;
using System.Collections.Generic;

public class Bag
{
    private enum ItemTypes
    {
        Gold, Gem, Cash, Invalid
    }

    private long totalGold;
    private long totalGems;
    private long totalCash;
    private long bagCapacity;
    private long bagLeftCapacity;
    private Dictionary<string, long> gold;
    private Dictionary<string, long> gems;
    private Dictionary<string, long> cash;

    public Bag(long bagCapacity)
    {
        this.TotalGold = 0;
        this.TotalGems = 0;
        this.TotalCash = 0;
        this.BagCapacity = bagCapacity;
        this.BagLeftCapacity = bagCapacity;
        this.gold = new Dictionary<string, long>();
        this.gems = new Dictionary<string, long>();
        this.cash = new Dictionary<string, long>();
    }

    public long TotalGold
    {
        get => totalGold;
        private set => totalGold = value;
    }

    public long TotalGems
    {
        get => totalGems;
        private set => totalGems = value;
    }

    public long TotalCash
    {
        get => totalCash;
        private set => totalCash = value;
    }

    public long BagCapacity
    {
        get => bagCapacity;
        private set => bagCapacity = value;
    }

    public long BagLeftCapacity
    {
        get => bagLeftCapacity;
        private set => bagLeftCapacity = value;
    }

    private ItemTypes GetItemType(string item)
    {
        ItemTypes itemType = ItemTypes.Invalid;

        if (item.Length == 3)
        {
            itemType = ItemTypes.Cash;
        }
        else if (item.ToLower().EndsWith("gem"))
        {
            itemType = ItemTypes.Gem;
        }
        else if (item.ToLower() == "gold")
        {
            itemType = ItemTypes.Gold;
        }

        return itemType;
    }

    private bool SkipItem(ItemTypes itemType, long amount)
    {
        bool isTypeValid = itemType != ItemTypes.Invalid;
        bool overflowsBag = this.BagLeftCapacity < amount;
        bool breaksAmountRule =
            itemType == ItemTypes.Gem && this.TotalGems + amount > this.TotalGold ||
            itemType == ItemTypes.Cash && this.TotalCash + amount > this.TotalGems;

        bool skipItem = !isTypeValid || overflowsBag || breaksAmountRule;

        return skipItem;
    }

    private void AddItem(Dictionary<string, long> dictionary, string item, long amount)
    {
        if (!dictionary.ContainsKey(item))
        {
            dictionary[item] = 0;
        }

        dictionary[item] += amount;
    }

    private void AddItemToBag(ItemTypes itemType, string item, long amount)
    {
        switch (itemType)
        {
            case ItemTypes.Gold:
                AddItem(this.gold, item, amount);
                this.TotalGold += amount;
                break;
            case ItemTypes.Gem:
                AddItem(this.gems, item, amount);
                this.TotalGems += amount;
                break;
            case ItemTypes.Cash:
                AddItem(this.cash, item, amount);
                this.TotalCash += amount;
                break;
        }
    }

    public void TryAddItem(string item, long amount)
    {
        ItemTypes itemType = GetItemType(item);

        if (SkipItem(itemType, amount))
        {
            return;
        }

        AddItemToBag(itemType, item, amount);
        this.BagLeftCapacity -= amount;
    }

    private void PrintContent(Dictionary<string, long> dictionary)
    {
        foreach (KeyValuePair<string, long> amountByItem
            in dictionary
                .OrderByDescending(p => p.Key)
                .ThenBy(p => p.Value))
        {                                                     
            string item = amountByItem.Key;
            long amount = amountByItem.Value;

            Console.WriteLine($"##{item} - {amount}");
        }
    }

    public void PrintContent()
    {
        if (this.gold.Count > 0)
        {
            Console.WriteLine($"<Gold> ${this.TotalGold}");

            PrintContent(this.gold);
        }

        if (this.gems.Count > 0)
        {
            Console.WriteLine($"<Gem> ${this.TotalGems}");

            PrintContent(this.gems);
        }

        if (this.cash.Count > 0)
        {
            Console.WriteLine($"<Cash> ${this.TotalCash}");

            PrintContent(this.cash);
        }
    }    
}