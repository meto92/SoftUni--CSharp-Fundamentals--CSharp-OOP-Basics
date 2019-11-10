using System;
using System.Collections.Generic;

public class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    { }

    protected override double IncreasedWeightFromFoodPiece => 1;

    public override ISet<Food.Foods> AnimalFoods => new HashSet<Food.Foods>
    {
        Food.Foods.Meat
    };

    public override void ProduceSound()
    {
        Console.WriteLine("ROAR!!!");
    }
}