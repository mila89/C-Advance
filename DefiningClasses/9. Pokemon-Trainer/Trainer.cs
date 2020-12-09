using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer()
        {
            Badges = 0;
        }
        public Trainer(string name,List<Pokemon> pokemon):this()
        {
            Name = name;
            PokemonList = pokemon;
        }
        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> PokemonList { get; set; }

    }
}
