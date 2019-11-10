using System;
using System.Linq;
using System.Collections.Generic;

public class Pizza
{
    public const int MaxTopicsCount = 10;

    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public Pizza(string name)
    {
        this.Name = name;
        this.toppings = new List<Topping>();
    }

    private string Name
    {
        set
        {
            if (value == string.Empty || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            this.name = value;
        }
    }

    public Dough Dough
    {
        get => dough;
        set => dough = value;
    }

    public void AddTopping(Topping topping)
    {
        if (this.toppings.Count == MaxTopicsCount)
        {
            throw new InvalidCastException("Number of toppings should be in range [0..10].");
        }

        this.toppings.Add(topping);
    }

    public double TotalCalories()
    {
        double doughCalories = this.dough.WeightInGrams * this.dough.CaloriesPerGram();
        double toppingsCalories = this.toppings.Sum(t => t.WeightInGrams * t.CaloriesPerGram());

        return doughCalories + toppingsCalories;
    }

    public override string ToString()
    {
        return $"{this.name} - {this.TotalCalories():f2} Calories.";
    }
}