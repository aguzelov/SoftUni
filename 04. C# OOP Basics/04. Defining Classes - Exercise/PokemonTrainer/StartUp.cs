using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        List<Trainer> trainers = new List<Trainer>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "Tournament")
        {
            string[] inputArr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string trainerName = inputArr[0];
            string pokemonName = inputArr[1];
            string element = inputArr[2];
            long health = int.Parse(inputArr[3]);

            Pokemon pokemon = new Pokemon(pokemonName, element, health);
            Trainer trainer = new Trainer(trainerName, pokemon);

            if (trainers.Contains(trainer))
            {
                int index = trainers.FindIndex(t => t.Name == trainerName);
                trainers[index].AddPokemon(pokemon);
            }
            else
            {
                trainers.Add(trainer);
            }
            
        }

        string elementInput = string.Empty;
        while ((elementInput = Console.ReadLine().Trim()) != "End")
        {
            trainers.ForEach(t => t.ElementCheck(elementInput));
        }

        trainers = trainers.OrderByDescending(t => t.NumberOfBadges).ToList();

        foreach(var trainer in trainers)
        {
            Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
        }
    }
}