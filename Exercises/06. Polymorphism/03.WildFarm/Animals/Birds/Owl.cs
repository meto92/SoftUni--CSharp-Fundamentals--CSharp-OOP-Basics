using System;
using System.Collections.Generic;

public class Owl : Bird
{
    public Owl(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    { }

    protected override double IncreasedWeightFromFoodPiece => 0.25;

    public override ISet<Food.Foods> AnimalFoods => new HashSet<Food.Foods>
    {
        Food.Foods.Meat
    };

    public override void ProduceSound()
    {
        Console.WriteLine("Hoot Hoot");
    }
}