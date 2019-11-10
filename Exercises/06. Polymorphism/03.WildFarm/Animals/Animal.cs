using System;
using System.Collections.Generic;

public abstract class Animal
{
    private string name;
    private double weight;
    private int foodEaten;

    public Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = 0;
    }

    public string Name
    {
        get => this.name;
        set => this.name = Utility.ValidateNullOrEmptyString(value, nameof(this.Name));
    }

    public double Weight
    {
        get => this.weight;
        set => this.weight = Utility.ValidateNonZeroPositiveNumber(value, nameof(this.Weight));
    }

    public int FoodEaten
    {
        get => this.foodEaten;
        set => this.foodEaten = (int)Utility.ValidatePositiveNumber(value, nameof(this.FoodEaten));
    }

    public abstract ISet<Food.Foods> AnimalFoods
    {
        get;
    }

    protected abstract double IncreasedWeightFromFoodPiece
    {
        get;
    }

    public abstract void ProduceSound();

    public void Eat(Food food)
    {
        Food.Foods foodType = Enum.Parse<Food.Foods>(food.GetType().Name);

        if (this.AnimalFoods.Contains(foodType))
        {
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * IncreasedWeightFromFoodPiece;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {foodType}!");
        }
    }

    public override string ToString()
    {
        string result = $"{this.GetType().Name} [{this.Name}";

        return result;
    }
}