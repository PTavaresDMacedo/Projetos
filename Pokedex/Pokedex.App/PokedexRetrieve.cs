using Pokedex.Model;
using Pokedex.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pokedex.App
{
    internal class PokedexRetrieve
    {
        private readonly IPokemonService _pokemonService = new PokemonService();

        public void MenuRetrieve()
        {
            int option = 0;

            do
            {
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Pesquisar Pokémon pelo número");
                Console.WriteLine("2 - Pesquisar Pokémon pelo nome");
                Console.WriteLine("3 - Mostrar todos os Pokémons cadastrados");

                option = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Insira o número do Pokémon: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Pokemon pokemonToRetrievedById = _pokemonService.Retrieve(id);
                        Console.WriteLine(JsonSerializer.Serialize(pokemonToRetrievedById));
                        Erase();
                        break;
                    case 2:
                        Console.WriteLine("Insira o nome do Pokémon: ");
                        string name = Console.ReadLine();
                        Pokemon pokemonToRetrievedByName = _pokemonService.Retrieve(name);
                        Console.WriteLine(JsonSerializer.Serialize(pokemonToRetrievedByName));
                        Erase();
                        break;
                    case 3:
                        List<Pokemon> allPokemons = _pokemonService.RetrieveAll();
                        Console.WriteLine(JsonSerializer.Serialize(allPokemons));
                        Erase();
                        break;
                }
            } while (option != 0);
        }
        public static void Erase()
        {
            Console.WriteLine("Ação bem sucedida. Pressione qualquer tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
