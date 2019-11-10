using System;
using System.Collections.Generic;

public class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    { }

    protected override double IncreasedWeightFromFoodPiece => 0.3;

    public override ISet<Food.Foods> AnimalFoods => new HashSet<Food.Foods>
    {
        Food.Foods.Vegetable,
        Food.Foods.Meat
    };

    public override void ProduceSound()
    {
        Console.WriteLine("Meow");
    }
}