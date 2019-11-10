using System;
using System.Collections.Generic;

public class Startup
{
    private static void SetCompany(Dictionary<string, Person> peopleByName, string name, string[] inputParams)
    {
        string companyName = inputParams[2];
        string department = inputParams[3];
        decimal salary = decimal.Parse(inputParams[4]);

        peopleByName[name].SetCompany(companyName, department, salary);
    }

    private static void AddPokemon(Dictionary<string, Person> peopleByName, string name, string[] inputParams)
    {
        string pokemonName = inputParams[2];
        string pokemonType = inputParams[3];

        peopleByName[name].AddPokemon(pokemonName, pokemonType);
    }

    private static void AddParent(Dictionary<string, Person> peopleByName, string name, string[] inputParams)
    {
        string parentName = inputParams[2];
        string parentBirthday = inputParams[3];

        peopleByName[name].AddParent(parentName, parentBirthday);
    }

    private static void AddChild(Dictionary<string, Person> peopleByName, string name, string[] inputParams)
    {
        string childName = inputParams[2];
        string childBirthday = inputParams[3];

        peopleByName[name].AddChild(childName, childBirthday);
    }

    private static void SetCar(Dictionary<string, Person> peopleByName, string name, string[] inputParams)
    {
        string carModel = inputParams[2];
        int carSpeed = int.Parse(inputParams[3]);

        peopleByName[name].SetCar(carModel, carSpeed);
    }

    public static void Main()
    {
        Dictionary<string, Person> peopleByName = new Dictionary<string, Person>();

        string input = null;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputParams = input.Split();

            string name = inputParams[0];

            if (!peopleByName.ContainsKey(name))
            {
                peopleByName[name] = new Person(name);
            }

            switch (inputParams[1])
            {
                case "company":
                    SetCompany(peopleByName, name, inputParams);
                    break;
                case "pokemon":
                    AddPokemon(peopleByName, name, inputParams);
                    break;
                case "parents":
                    AddParent(peopleByName, name, inputParams);
                    break;
                case "children":
                    AddChild(peopleByName, name, inputParams);
                    break;
                case "car":
                    SetCar(peopleByName, name, inputParams);
                    break;
            }
        }

        string requestedName = Console.ReadLine();

        Console.WriteLine(peopleByName[requestedName]);
    }
}