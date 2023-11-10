using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Model;
using Receitas.Service.Ingredients;
using Receitas.Service.Measures;
using Receitas.Service.RecipeIngredients;
using Receitas.Service.Recipes;

namespace Tastebook.WebApp.Pages.RecipeIngredients
{
    public class CreateModel : PageModel
    {
        private readonly IRecipeIngredientService _recipeIngredientService;
        private readonly IRecipeService _recipeService;
        private readonly IIngredientService _ingredientService;
        private readonly IMeasureService _measureService;

        public CreateModel(IRecipeIngredientService recipeIngredientService, IRecipeService recipeService, IIngredientService ingredientService, IMeasureService measureService)
        {
            _recipeIngredientService = recipeIngredientService;
            _recipeService = recipeService;
            _ingredientService = ingredientService;
            _measureService = measureService;
        }

        public List<RecipeIngredient> RecipeIngredients { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Measure> Measures { get; set; }
        public Recipe Recipe { get; set; }

        public void OnGet(int id)
        {
            RecipeIngredients = _recipeIngredientService.RetrieveAllByRecipeId(id);
            Ingredients = _ingredientService.RetrieveAll();
            Measures = _measureService.RetrieveAll();
            Recipe = _recipeService.Retrieve(id);
        }

        public IActionResult OnPost()
        {
            RecipeIngredient recipeIngredient = new RecipeIngredient();

            Recipe recipe = new Recipe();
            recipe.Id = Convert.ToInt32(Request.Form["id_recipe"]);
            recipeIngredient.Recipe = recipe;

            Ingredient ingredient = new Ingredient();
            ingredient.Id = Convert.ToInt32(Request.Form["id_ingredient"]);
            recipeIngredient.Ingredient = ingredient;

            recipeIngredient.Quantity = Convert.ToInt64(Request.Form["quantity"]);

            Measure measure = new Measure();
            measure.Id = Convert.ToInt32(Request.Form["id_measure"]);
            recipeIngredient.Measure = measure;

            _recipeIngredientService.Create(recipeIngredient);
            return RedirectToPage("/RecipeIngredients/Create", new { id = recipe.Id });
        }
    }
}
