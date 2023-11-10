using Pokedex.Model;
using Pokedex.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Pokedex.Model.Type;

namespace Pokedex.App
{
    internal class Pokedex
    {
        private readonly IPokemonService _pokemonService = new PokemonService();
        public void MenuPokedex()
        {

            int option = 0;

            Console.WriteLine("BEM VINDO À SUA POKÉDEX");

            do
            {
                Console.WriteLine("Escolha uma opção:");

                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Cadastrar Pokémon");
                Console.WriteLine("2 - Pesquisar Pokémon");
                Console.WriteLine("3 - Atualizar Pokémon");
                Console.WriteLine("4 - Apagar Pokémon");

                option = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (option)
                {
                    case 1:
                        Pokemon pokemon = new Pokemon();
                        Console.WriteLine("Insira o nome do Pokémon: ");
                        pokemon.Name = Console.ReadLine();
                        Type pokemonType = new Type();
                        Console.WriteLine("Insira o tipo do Pokémon: ");
                        pokemonType.TypeName = Console.ReadLine();
                        pokemon.Type = pokemonType;
                        Console.WriteLine("Insira o level do Pokémon: ");
                        pokemon.Level = Convert.ToInt32(Console.ReadLine());
                        Pokemon newPokemon = _pokemonService.Create(pokemon);
                        Console.WriteLine(pokemon);
                        Erase();
                        break;
                    case 2:
                        PokedexRetrieve pokedexRetrieve = new PokedexRetrieve();
                        pokedexRetrieve.MenuRetrieve();
                        break;
                    case 3:
                        Console.WriteLine("Insira o número do Pokémon a atualizar: ");
                        int idToUpdate = Convert.ToInt32(Console.ReadLine());
                        Pokemon pokemonToUpdate = _pokemonService.Retrieve(idToUpdate);
                        Type pokemonTypeToUpdate = new Type();
                        Console.WriteLine("Insira o novo nome do Pokémon: ");
                        string newName = Console.ReadLine();
                        Console.WriteLine("Insira o novo tipo do Pokémon: ");
                        string newType = Console.ReadLine();
                        Console.WriteLine("Insira o novo nível do Pokémon: ");
                        int newLevel = Convert.ToInt32(Console.ReadLine());
                        pokemonToUpdate.Id = idToUpdate;
                        pokemonToUpdate.Name = newName;
                        pokemonToUpdate.Level = newLevel;
                        pokemonTypeToUpdate.TypeName = newType;
                        pokemonToUpdate.Type = pokemonTypeToUpdate;
                        Pokemon updatedPokemon = _pokemonService.Update(pokemonToUpdate);
                        Console.WriteLine(updatedPokemon);
                        Erase();
                        break;
                    case 4:
                        Console.WriteLine("Insira o número do Pokémon a apagar: ");
                        int idToDelete = Convert.ToInt32(Console.ReadLine());
                        _pokemonService.Delete(idToDelete);
                        Erase();
                        break;
                }

            }
            while (option != 0);
        }

        public static void Erase()
        {
            Console.WriteLine("Ação bem sucedida. Pressione qualquer tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }

        public static void ChooseType()
        {
            int choice = 0;
            do
            {

                Console.WriteLine("[1] Fogo" +
                    "[2] Água" +
                    "[3] Planta" +
                    "[4] Elétrico" +
                    "[5] Normal" +
                    "[6] Psíquico" +
                    "[7] Voador" +
                    "[8] Venenoso" +
                    "[9] Fantasma" +
                    "[10] Dragão" +
                    "[11] Pedra" +
                    "[12] Gelo" +
                    "[13] Lutador" +
                    "[14] Inseto" +
                    "[15] Ferro" +
                    "[16] Sombrio" +
                    "[17] Fada" + 
                    "[18] Terra" +
                    "[0] Sair");

                switch (choice)
                {
                    case 1:
                }

            } while (choice != 0);
        }
    }
}
