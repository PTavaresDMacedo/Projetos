// See https://aka.ms/new-console-template for more information

using Receitas.Model;
using Receitas.Service;
using Receitas.Repository;
using System.Diagnostics;
using System.Globalization;
using Receitas.Repository.Ingredients;
using Receitas.Service.Ingredients;

internal class Program
{
    private static void Main(string[] args)
    {
        IIngredientRepository repository = new IngredientRepository();
        IIngredientService service = new IngredientService(repository);


    }
}
