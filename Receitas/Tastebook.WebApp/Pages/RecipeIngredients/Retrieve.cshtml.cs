using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Model;
using Receitas.Service.RecipeIngredients;

namespace Tastebook.WebApp.Pages.RecipeIngredients
{
    public class RetrieveModel : PageModel
    {
        private readonly IRecipeIngredientService _recipeIngredientService;

        public RetrieveModel(IRecipeIngredientService recipeIngredientService)
        {
            _recipeIngredientService = recipeIngredientService;
        }

        public List<RecipeIngredient> RecipeIngredients { get; set; }

        public void OnGet(int id)
        {
            RecipeIngredients = _recipeIngredientService.RetrieveAllByRecipeId(id);
        }
    }
}
