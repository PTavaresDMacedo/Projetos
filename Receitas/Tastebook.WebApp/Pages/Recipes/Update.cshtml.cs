using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Model;
using Receitas.Service.Categories;
using Receitas.Service.Difficulties;
using Receitas.Service.Recipes;
using Receitas.Service.Users;

namespace Tastebook.WebApp.Pages.Recipes
{
    public class UpdateModel : PageModel
    {
        private readonly IRecipeService _recipeService;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        private readonly IDifficultyService _difficultyService;

        public UpdateModel(IRecipeService recipeService, IUserService userService, ICategoryService categoryService, IDifficultyService difficultyService)
        {
            _recipeService = recipeService;
            _userService = userService;
            _categoryService = categoryService;
            _difficultyService = difficultyService;
        }

        public Recipe Recipe { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
        public Difficulty Difficulty { get; set; }

        public void OnGet(int id)
        {
            Recipe = _recipeService.Retrieve(id);
            User = _userService.Retrieve(Recipe.Author.Id);
            Category = _categoryService.Retrieve(Recipe.Category.Id);
            Difficulty = _difficultyService.Retrieve(Recipe.Difficulty.Id);
        }

        public IActionResult OnPost()
        {
            Recipe recipe = new Recipe();
            recipe.Id = Convert.ToInt32(Request.Form["id"]);
            recipe.Name = Convert.ToString(Request.Form["name"]);

            User user = new User();
            user.Id = Convert.ToInt32(Request.Form["author"]);
            recipe.Author = user;

            Category category = new Category();
            category.Id = Convert.ToInt32(Request.Form["category"]);
            recipe.Category = category;

            recipe.PreparationTime = Convert.ToInt32(Request.Form["prep_time"]);
            recipe.Description = Convert.ToString(Request.Form["description"]);

            Difficulty difficulty = new Difficulty();
            difficulty.Id = Convert.ToInt32(Request.Form["difficulty"]);
            recipe.Difficulty = difficulty;

            _recipeService.Update(recipe);
            return Redirect("/Recipes/RetrieveAll");
        }
    }
}
