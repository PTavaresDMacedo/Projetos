using McKing.Model;
using McKing.Repository.Interface;
using McKing.Service.Interface;

namespace McKing.Service.Implementation
{
    public class RecipeService : IService<Recipe, int>
    {
        private readonly IRepository<Recipe, int> _repository;
        private readonly IService<Difficulty, int> _difficultyService;
        private readonly IService<Category, int> _categoryService;
        private readonly IService<User, int> _userService;
        private readonly IIngredientLineService _ingredientLineService;

        public RecipeService(IRepository<Recipe, int> repository, IService<Difficulty, int> difficultyService, IService<Category, int> categoryService, IService<User, int> userService, IIngredientLineService ingredientLineService)
        {
            _repository = repository;
            _difficultyService = difficultyService;
            _categoryService = categoryService;
            _userService = userService;
            _ingredientLineService = ingredientLineService;
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
            recipe.Category = _categoryService.Retrieve(recipe.Category.Id);
            recipe.Ingredients = _ingredientLineService.RetrieveAllByRecipeId(recipe.Id);
            recipe.Author = _userService.Retrieve(recipe.Author.Id);
            recipe.Author.Password = "";
            recipe.Author.Email = "";
            return recipe;
        }

        public List<Recipe> RetrieveAll()
        {
            List<Recipe> recipes = _repository.RetrieveAll();
            foreach (Recipe recipe in recipes)
            {
                recipe.Difficulty = _difficultyService.Retrieve(recipe.Difficulty.Id);
                recipe.Category = _categoryService.Retrieve(recipe.Category.Id);
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
