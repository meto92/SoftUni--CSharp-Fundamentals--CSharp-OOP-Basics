using System;

public class Topping
{
    public const int MinWeightInGrams = 1;
    public const int MaxWeightInGrams = 50;

    private enum TypeMultiplier
    {
        meat = 12, veggies = 8, cheese = 11, sauce = 9
    }

    private TypeMultiplier typeMultiplier;
    private int weightInGrams;
    private string type;

    public Topping(string type, int weightInGrams)
    {
        this.Multiplier = type;
        this.type = type;
        this.WeightInGrams = weightInGrams;
    }

    private string Multiplier
    {
        set
        {
            if (!Enum.TryParse(value.ToLower(), out this.typeMultiplier))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
        }
    }

    public int WeightInGrams
    {
        get => weightInGrams;

        set
        {
            if (value < MinWeightInGrams || value > MaxWeightInGrams)
            {
                throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
            }

            weightInGrams = value;
        }
    }

    public double CaloriesPerGram()
    {
        double caloriesPerGram = (double)this.typeMultiplier / 5;

        return caloriesPerGram;
    }
}