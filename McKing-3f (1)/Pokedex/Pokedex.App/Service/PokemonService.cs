

using Pokedex.App.Repository;
using Pokedex.Model;
using Pokedex.Repository;
using System.Collections.Generic;

namespace Pokedex.Service
{
    internal class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository = new PokemonRepositorySQL();

        public Pokemon Create(Pokemon pokemon)
        {
            return _pokemonRepository.Create(pokemon);
        }

        public void Delete(int Id)
        {
            _pokemonRepository.Delete(Id);
        }

        public Pokemon Retrieve(int Id)
        {
            return _pokemonRepository.Retrieve(Id);
        }

        public Pokemon Retrieve(string Name)
        {
            return _pokemonRepository.Retrieve(Name);
        }

        public List<Pokemon> RetrieveAll()
        {
            return _pokemonRepository.RetrieveAll();
        }

        public Pokemon Update(Pokemon pokemon)
        {
            return _pokemonRepository.Update(pokemon);
        }

      
    }
}
