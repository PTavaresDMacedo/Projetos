using Pokedex.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Repository
{
    internal class PokemonRepositoryList : IPokemonRepository
    {
        private static List<Pokemon> _pokemonList = new List<Pokemon>();

        private static int id = 1;
        

        public Pokemon Create(Pokemon pokemon)
        {
            pokemon.Id = id;
            id++;
            _pokemonList.Add(pokemon);
            return pokemon;
        }

        public Pokemon Retrieve(int id)
        {
            foreach(Pokemon pokemon in _pokemonList)
            {
                if (pokemon.Id == id)
                {
                    return pokemon;
                }
            }
            throw new Exception("Pokémon não encontrado.");
        }

        public Pokemon Retrieve(string Name)
        {
            foreach (Pokemon pokemon in _pokemonList)
            {
                if (pokemon.Name == Name)
                {
                    return pokemon;
                }
            }
            throw new Exception("Pokémon não encontrado.");
        }

        public List<Pokemon> RetrieveAll()
        {
            return _pokemonList;
        }

        public Pokemon Update(Pokemon pokemon)
        {
            foreach(Pokemon poke in _pokemonList)
            {
                if (poke.Id == id)
                {
                    poke.Name = pokemon.Name;
                    poke.Level = pokemon.Level;
                    poke.Type = pokemon.Type;

                }
                return pokemon;
            }
            throw new Exception("Pokémon não encontrado.");
        }

        public void Delete(int Id)
        {
            Pokemon pokemon = Retrieve(Id);
            _pokemonList.Remove(pokemon);
        }
    }
}
