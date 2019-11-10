using System;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        List<Animal> animals = new List<Animal>();

        string input = null;

        while ((input = Console.ReadLine()) != "Beast!")
        {
            string[] animalParams = Console.ReadLine().Split();

            string name = animalParams[0];
            string ageStr = animalParams[1];
            string gender = animalParams[2];

            try
            {
                if (!Enum.TryParse(input, out Animal.SupportedAnimals animalType))
                {
                    throw new InvalidInputException();
                }

                Animal animal = AnimalFactory.GetAnimal(animalType, name, ageStr, gender);

                animals.Add(animal);
            }
            catch (InvalidInputException iie)
            {
                Console.WriteLine(iie.Message);
            }
        }

        animals.ForEach(animal =>
        {
            Console.WriteLine(animal);
            animal.ProduceSound();
        });
    }
}