using System;
using Pokedex.App.Repository;

namespace Pokedex.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SISTEMA DE GERENCIAMENTO POKÉMON");

            int option = 0;
            do
            {
                Console.WriteLine("Escolha uma opção:");

                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Acessar Pokédex");
                Console.WriteLine("2 - Capturar novo Pokémon");

                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Pokedex pokedex = new Pokedex();
                        Console.Clear();
                        pokedex.MenuPokedex();
                        break;
                    case 2:
                        Console.WriteLine("Opção indisponível no momento");
                        Console.ReadKey();
                        break;
                }

            }
            while (option != 0);

        }

        public static void Erase()
        {
            Console.Clear();
            Console.ReadKey();
        }
    }
}
