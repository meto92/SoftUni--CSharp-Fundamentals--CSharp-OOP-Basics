using System;
using System.Collections.Generic;

public class Hen : Bird
{
    public Hen(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    { }

    protected override double IncreasedWeightFromFoodPiece => 0.35;

    public override ISet<Food.Foods> AnimalFoods => new HashSet<Food.Foods>
    {
        Food.Foods.Vegetable,
        Food.Foods.Meat,
        Food.Foods.Fruit,
        Food.Foods.Seeds
    };

    public override void ProduceSound()
    {
        Console.WriteLine("Cluck");
    }
}