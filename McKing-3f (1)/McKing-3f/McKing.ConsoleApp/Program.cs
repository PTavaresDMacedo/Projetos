using McKing.Model;
using McKing.Repository.Implementation;
using McKing.Repository.Interface;
using McKing.Service.Implementation;
using McKing.Service.Interface;
using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        IRepository<Difficulty, int> difficultyRepository = new DifficultyRepository();
        IService<Difficulty, int> difficultyService = new DifficultyService(difficultyRepository);
        IRepository<Recipe, int> repository = new RecipeRepository();
        IService<Recipe, int> service = new RecipeService(repository, difficultyService);

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.WriteIndented = true;

        Console.WriteLine(JsonSerializer.Serialize(service.RetrieveAll(), options));
    }

    /*
        Recipe recipe = new Recipe();
        recipe.Title = "Rocovo";

        User author = new User();
        author.Id = 1;
        recipe.Author = author;

        Category category = new Category(); 
        category.Id = 1;
        recipe.Category = category;

        Difficulty difficulty = new Difficulty();
        difficulty.Id = 1;
        recipe.Difficulty = difficulty;

        recipe.PrepTime = 60;
        recipe.PrepMethod = "Mix well";
        recipe.IsApproved = true;
    */
}