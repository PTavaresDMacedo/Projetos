using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Server.IIS.Core;
using Receitas.Model;
using Receitas.Service.Ingredients;
using Receitas.Service.Measures;
using Receitas.Service.RecipeIngredients;

namespace Tastebook.WebApp.Pages.RecipeIngredients
{
    public class UpdateModel : PageModel
    {
        private readonly IRecipeIngredientService _recipeIngredientService;
        private readonly IIngredientService _ingredientService;
        private readonly IMeasureService _measureService;

        public UpdateModel(IRecipeIngredientService recipeIngredientService, IIngredientService ingredientService, IMeasureService measureService)
        {
            _recipeIngredientService = recipeIngredientService;
            _ingredientService = ingredientService;
            _measureService = measureService;
        }

        public RecipeIngredient RecipeIngredient { get; set; }
        public Ingredient Ingredient { get; set; }
        public Measure Measure { get; set; }

        public void OnGet(int id)
        {
            RecipeIngredient = _recipeIngredientService.Retrieve(id);
            Ingredient = _ingredientService.Retrieve(RecipeIngredient.Ingredient.Id);
            Measure = _measureService.Retrieve(RecipeIngredient.Measure.Id);
        }

        public IActionResult OnPost()
        {
            RecipeIngredient recipeIngredient = new RecipeIngredient();
            recipeIngredient.Id = Convert.ToInt32(Request.Form["id"]);
            recipeIngredient.Quantity = Convert.ToInt32(Request.Form["quantity"]);

            Ingredient ingredient = new Ingredient();
            ingredient.Id = Convert.ToInt32(Request.Form["id_ingredient"]);
            recipeIngredient.Ingredient = ingredient;

            Measure measure = new Measure();
            measure.Id = Convert.ToInt32(Request.Form["id_measure"]);
            recipeIngredient.Measure = measure;

            //_recipeIngredientService.Update(_recipeIngredientService);
            return Redirect("/Recipes/RetrieveALl");
        }
    }
}
