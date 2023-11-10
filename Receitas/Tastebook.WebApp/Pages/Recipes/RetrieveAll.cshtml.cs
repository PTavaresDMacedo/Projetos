using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Model;
using Receitas.Service.Categories;
using Receitas.Service.Difficulties;
using Receitas.Service.Recipes;
using Receitas.Service.Users;

namespace Tastebook.WebApp.Pages.Recipes
{
    public class RetrieveAllModel : PageModel
    {
        private readonly IRecipeService _recipeService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;
        private readonly IDifficultyService _difficultyService;

        public RetrieveAllModel(IRecipeService recipeService, ICategoryService categoryService, IUserService userService, IDifficultyService difficultyService)
        {
            _recipeService = recipeService;
            _categoryService = categoryService;
            _userService = userService;
            _difficultyService = difficultyService;
        }

        public List<Recipe> Recipes { get; set; }
        public List<Category> Categories { get; set; }
        public List<Difficulty> Difficulties { get; set; }
        public List<User> Users { get; set; }

        public void OnGet()
        {
            Recipes = _recipeService.RetrieveAll();
            Categories = _categoryService.RetrieveAll();
            Difficulties = _difficultyService.RetrieveAll();
            Users = _userService.RetrieveAll();
        }

        public IActionResult OnPost()
        {
            Recipe recipe = new Recipe();
            recipe.Name = Convert.ToString(Request.Form["name"]);
            recipe.PreparationTime = Convert.ToInt32(Request.Form["prep_time"]);
            recipe.Description = Convert.ToString(Request.Form["description"]);
            recipe.IsApproved = Convert.ToBoolean(Request.Form["is_approved"]);

            User user = new User();
            user.Id = Convert.ToInt32(Request.Form["author"]);
            recipe.Author = user;

            Category category = new Category();
            category.Id = Convert.ToInt32(Request.Form["category"]);
            recipe.Category = category;

            Difficulty difficulty = new Difficulty();
            difficulty.Id = Convert.ToInt32(Request.Form["difficulty"]);
            recipe.Difficulty = difficulty;

            recipe =   _recipeService.Create(recipe);
            return RedirectToPage("/RecipeIngredients/Create", new {id = recipe.Id});
        }
    }
}
