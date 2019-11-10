using System;
using System.Linq;
using System.Collections.Generic;

public class Startup
{
    private static IAnimal GetAnimal(string[] animalParams)
    {
        IAnimal animal = null;

        if (animalParams[0] == "Pet")
        {
            string petName = animalParams[1];
            string petBirthdate = animalParams[2];

            animal = new Pet(petName, petBirthdate);
        }
        else
        {
            string citizenName = animalParams[1];
            int citizenAge = int.Parse(animalParams[2]);
            string citizenId = animalParams[3];
            string citizenBirthdate = animalParams[4];

            animal = new Citizen(citizenName, citizenAge, citizenId, citizenBirthdate);
        }

        return animal;
    }

    private static List<IAnimal> ReadAnimals()
    {
        List<IAnimal> animals = new List<IAnimal>();

        string input = null;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] animalParams = input.Split();

            string animalType = animalParams[0];

            IAnimal animal = null;

            switch (animalType)
            {
                case "Pet":
                case "Citizen":
                    animal = GetAnimal(animalParams);
                    break;
                default:
                    continue;
            }

            animals.Add(animal);
        }

        return animals;
    }

    public static void Main()
    {
        List<IAnimal> animals = ReadAnimals();

        string birthdateYearStr = Console.ReadLine();

        animals.Where(animal => animal.Birthdate.EndsWith(birthdateYearStr))
            .ToList()
            .ForEach(Console.WriteLine);
    }
}