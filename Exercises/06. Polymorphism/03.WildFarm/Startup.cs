using System;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        List<Animal> animals = new List<Animal>();
        
        string input = null;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] animalParams = input.Split();
            string[] foodParams = Console.ReadLine().Split();

            Animal animal = AnimalFactory.GetAnimal(animalParams);
            Food food = FoodFactory.GetFood(foodParams);

            animal.ProduceSound();
            animal.Eat(food);

            animals.Add(animal);
        }

        animals.ForEach(Console.WriteLine);
    }
}