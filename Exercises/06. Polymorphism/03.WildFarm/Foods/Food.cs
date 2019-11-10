using System;

public abstract class Food
{
    public enum Foods
    {
        Vegetable,
        Meat,
        Fruit,
        Seeds
    }

    private const string InvalidQuantityMessage = "Quantity must be positive!";

    private int quantity;

    public Food()
        : this(0)
    { }

    public Food(int quantity)
    {
        this.Quantity = quantity;
    }

    public int Quantity
    {
        get => this.quantity;

        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(this.Quantity), InvalidQuantityMessage);
            }

            this.quantity = value;
        }
    }
}