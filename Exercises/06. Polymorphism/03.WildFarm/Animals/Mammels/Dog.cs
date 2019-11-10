using System;
using System.Collections.Generic;

public class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    { }

    protected override double IncreasedWeightFromFoodPiece => 0.4;

    public override ISet<Food.Foods> AnimalFoods => new HashSet<Food.Foods>
    {
        Food.Foods.Meat
    };

    public override void ProduceSound()
    {
        Console.WriteLine("Woof!");
    }
}