using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Model;
using Receitas.Service.Recipes;

namespace Tastebook.WebApp.Pages.Recipes
{
    public class RetrieveModel : PageModel
    {
        private readonly IRecipeService _recipeService;

        public Recipe Recipe { get; set; }
        public RetrieveModel(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public void OnGet(int id)
        {
            Recipe = _recipeService.Retrieve(id);
        }
    }
}
