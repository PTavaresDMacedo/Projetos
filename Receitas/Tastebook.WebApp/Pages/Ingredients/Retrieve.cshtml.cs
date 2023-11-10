using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Model;
using Receitas.Service.Ingredients;

namespace Tastebook.WebApp.Pages.Ingredients
{
    public class RetrieveModel : PageModel
    {
        private readonly IIngredientService _ingredientService;

        public RetrieveModel(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public Ingredient Ingredient { get; set; }

        public void OnGet(int id)
        {
            Ingredient = _ingredientService.Retrieve(id);
        }
    }
}
