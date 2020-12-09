using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class Program
    {

        static void Main()
        {
            Dictionary<string, Trainer> trainersList = new Dictionary<string, Trainer>();
            string[] inputTrainer = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (inputTrainer[0] != "Tournament")
            {
                string trainerName = inputTrainer[0];
                if (trainersList.ContainsKey(trainerName))
                {
                    trainersList[trainerName].PokemonList.Add(new Pokemon(inputTrainer[1], inputTrainer[2], int.Parse(inputTrainer[3])));
                }
                else
                {
                    Pokemon currentPokemon = new Pokemon(inputTrainer[1], inputTrainer[2], int.Parse(inputTrainer[3]));
                    List<Pokemon> pokemonList = new List<Pokemon>();
                    pokemonList.Add(currentPokemon);
                    Trainer currentTrainer = new Trainer(trainerName, pokemonList);
                    trainersList.Add(currentTrainer.Name, currentTrainer);
                }
                inputTrainer = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                OperateHealth(command, trainersList);
                command = Console.ReadLine();
            }
            Dictionary<string, Trainer> tempTrainers = trainersList;
            PrintTrainers(trainersList, IsTwoTrainers(tempTrainers));
        }

        static void PrintTrainers(Dictionary<string, Trainer> list, bool twoTrainers)
        {
            if (!twoTrainers)
            {
                foreach (var trainer in list.Values)
                {
                    Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.PokemonList.Count}");
                }
            }
            else
            {
                foreach (var trainer in list.Values.OrderByDescending(t => t.Badges))
                {
                    Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.PokemonList.Count}");
                }
            }

        }
        static bool IsTwoTrainers(Dictionary<string, Trainer> list)
        {
            Trainer temp = new Trainer();
            foreach (var item in list.Values.OrderByDescending(b => b.Badges))
            {
                if (temp.Badges == item.Badges)
                    return true;
                else
                    temp = item;
            }
            return false;
        }
        static void OperateHealth(string command, Dictionary<string, Trainer> list)
        {

            foreach (var trainer in list.Values.Where(x => x.PokemonList.Count > 0))
            {
                bool isExist = false;
                foreach (var pokemon in trainer.PokemonList)
                {
                    if (pokemon.Element == command)
                    {
                        trainer.Badges++;
                        isExist = true;
                        break;
                    }
                }
                if (!isExist)
                {
                    foreach (var pokemon in trainer.PokemonList)
                    {
                        pokemon.Health -= 10;
                        if (pokemon.Health <= 0)
                            trainer.PokemonList.Remove(pokemon);
                        if (trainer.PokemonList.Count == 0)
                            break;
                    }
                }
            }

        }
    }
}
