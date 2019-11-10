using System;
using System.Linq;
using System.Collections.Generic;

public class Startup
{
    private static Dictionary<string, Trainer> GetTrainers()
    {
        Dictionary<string, Trainer> trainersByName = new Dictionary<string, Trainer>();

        string input = null;

        while ((input = Console.ReadLine()) != "Tournament")
        {
            string[] inputParams = input.Split();

            string trainerName = inputParams[0];
            string pokemonName = inputParams[1];
            string pokemonElement = inputParams[2];
            int pokemonHealth = int.Parse(inputParams[3]);

            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            if (!trainersByName.ContainsKey(trainerName))
            {
                Trainer trainer = new Trainer(trainerName);

                trainersByName[trainerName] = trainer;
            }

            trainersByName[trainerName].Pokemons.Add(pokemon);
        }

        return trainersByName;
    }

    private static void ReadAndProcessCommands(Dictionary<string, Trainer> trainersByName)
    {
        string input = null;

        while ((input = Console.ReadLine()) != "End")
        {
            string element = input;

            foreach (Trainer trainer in trainersByName.Values)
            {
                List<Pokemon> trainerPokemons = trainer.Pokemons;

                if (trainerPokemons.Any(pokemon => pokemon.Element == element))
                {
                    trainer.BadgesCount++;
                }
                else
                {
                    foreach (Pokemon pokemon in trainerPokemons)
                    {
                        pokemon.Health -= 10;
                    }

                    trainerPokemons.RemoveAll(pokemon => pokemon.Health <= 0);
                }
            }
        }
    }

    public static void Main()
    {
        Dictionary<string, Trainer> trainersByName = GetTrainers();

        ReadAndProcessCommands(trainersByName);

        trainersByName.Values
            .OrderByDescending(trainer => trainer.BadgesCount)
            .ToList()
            .ForEach(Console.WriteLine);
    }
}