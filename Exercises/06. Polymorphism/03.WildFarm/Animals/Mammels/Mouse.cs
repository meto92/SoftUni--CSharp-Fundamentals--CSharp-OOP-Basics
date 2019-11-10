using System;
using System.Collections.Generic;

public class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    { }

    protected override double IncreasedWeightFromFoodPiece => 0.1;

    public override ISet<Food.Foods> AnimalFoods => new HashSet<Food.Foods>
    {
        Food.Foods.Vegetable,
        Food.Foods.Fruit
    };

    public override void ProduceSound()
    {
        Console.WriteLine("Squeak");
    }
}