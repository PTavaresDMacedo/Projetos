using Receitas.Model;
using Receitas.Repository.Recipes;
using Receitas.Service.Categories;
using Receitas.Service.Difficulties;
using Receitas.Service.RecipeIngredients;
using Receitas.Service.Users;

namespace Receitas.Service.Recipes
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _repository;
        private readonly IDifficultyService _difficultyService;
        private readonly ICategoryService _categorySevrice;
        private readonly IUserService _userService;
        private readonly IRecipeIngredientService _recipeIngredientService;

        public RecipeService(IRecipeRepository repository, IDifficultyService difficultyService, ICategoryService categorySevrice, IUserService userService, IRecipeIngredientService recipeIngredientService)
        {
            _repository = repository;
            _difficultyService = difficultyService;
            _categorySevrice = categorySevrice;
            _userService = userService;
            _recipeIngredientService = recipeIngredientService;
        }

        public Recipe Create(Recipe recipe)
        {
            return _repository.Create(recipe);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Recipe Retrieve(int id)
        {
            Recipe recipe = _repository.Retrieve(id);
            recipe.Difficulty = _difficultyService.Retrieve(recipe.Difficulty.Id);
            recipe.Category = _categorySevrice.Retrieve(recipe.Category.Id);
            recipe.Author = _userService.Retrieve(recipe.Author.Id);
            recipe.Author.Password = "";
            recipe.Author.Email = "";
            recipe.Ingredients = _recipeIngredientService.RetrieveAllByRecipeId(recipe.Id);
            return recipe;
        }

        public Recipe Retrieve(string name)
        {
            Recipe recipe = _repository.Retrieve(name);
            recipe.Difficulty = _difficultyService.Retrieve(recipe.Difficulty.Id);
            recipe.Category = _categorySevrice.Retrieve(recipe.Category.Id);
            recipe.Author = _userService.Retrieve(recipe.Author.Id);
            recipe.Author.Password = "";
            recipe.Author.Email = "";
            recipe.Ingredients = _recipeIngredientService.RetrieveAllByRecipeId(recipe.Id);
            return recipe;
        }

        public List<Recipe> RetrieveAll()
        {
            List<Recipe> recipes = _repository.RetrieveAll();
            foreach (Recipe recipe in recipes)
            {
                recipe.Difficulty = _difficultyService.Retrieve(recipe.Difficulty.Id);
                recipe.Category = _categorySevrice.Retrieve(recipe.Category.Id);
                recipe.Author = _userService.Retrieve(recipe.Author.Id);
                recipe.Author.Password = "";
                recipe.Author.Email = "";
            }
            return recipes;
        }

        public Recipe Update(Recipe recipe)
        {
            return _repository.Update(recipe);
        }
    }
}
